using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FunWithCSharpAsync
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cts;

        public MainForm()
        {
            InitializeComponent();
        }

        // void is only reserved for event callbacks
        private async void btnCallMethod_Click(object sender, EventArgs e)
        {
            this.textBox1.Text += "Calling method async!\r\n";
            this.textBox1.Text += await DoWorkAsync();
        }

        // Task<T> should be used with awaitable
        private async Task<string> DoWorkAsync()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(5000);                 
                return "Done with work!\r\n";
            });
        }

        private async void btnVoidMethodCall_Click(object sender, EventArgs e)
        {
            await MethodReturningVoidAsync();
            textBox1.Text += "Done!\r\n";
        }

        // Watch Task here! not void
        private async Task MethodReturningVoidAsync()
        {
            await Task.Run(() =>
            { /* Do some work here... */
                Thread.Sleep(4000);
            });
        }

        private async void btnMutliAwaits_Click(object sender, EventArgs e)
        {
            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with first task!");

            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with second task!");

            await Task.Run(() => { Thread.Sleep(2000); });
            MessageBox.Show("Done with third task!");
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            Run_btn.Enabled = false;
            try
            {
                await Task.Delay(20000, cts.Token);
                textBox1.Text += "Done!\r\n";
            }
            catch(OperationCanceledException ex)
            {
                textBox1.Text += "Cancelled!\r\n";
            }
            finally
            {
                Run_btn.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
        }

        private async void btnProgress_Click(object sender, EventArgs e)
        {
            Btn_Progress.Enabled = false;
            try
            {
                await Task.Run(
                    () => DoProcessing(
                        new Progress<int>(p => textBox1.Text += $"{p}\r\n")
                        ));
            }
            finally
            {
                Btn_Progress.Enabled = true;
            }
        }

        private void DoProcessing(IProgress<int> progress)
        {
            for (int i = 0; i != 5; ++i)
            {
                Thread.Sleep(100); // CPU-bound work
                progress?.Report(i);
            }
        }
    }
}
