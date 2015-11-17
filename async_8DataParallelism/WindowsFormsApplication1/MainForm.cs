using System;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {

        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public MainForm()
        {
            InitializeComponent();
        }
        private void btnProcessImages_Click(object sender, EventArgs e)
        {
            // Start a new "task" to process the files.
            Task.Factory.StartNew(() =>
            {
                ProcessFiles();
            });
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // This will be used to tell all the worker threads to stop!
            cancelToken.Cancel();
        }
        private void ProcessFiles()
        {
            ParallelOptions parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            // Load up all *.jpg files, and make a new folder for the modified data.
            string[] files = Directory.GetFiles(@"C:\_test\photos", "*.jpg", SearchOption.AllDirectories);
            string newDir = @"C:\_test\photos\ModifiedPictures";
            Directory.CreateDirectory(newDir);

            try
            {
                Parallel.ForEach(files, parOpts, currentFile =>
                    {
                        parOpts.CancellationToken.ThrowIfCancellationRequested();

                        string filename = Path.GetFileName(currentFile);
                        using (Bitmap bitmap = new Bitmap(currentFile))
                        {
                            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            bitmap.Save(Path.Combine(newDir, filename));

                        }
                // Invoke on the Form object, to allow secondary threads to access controls
                // in a thread-safe manner.
                this.Invoke((Action)delegate
                        {
                            this.Text = string.Format("Processing {0} on thread {1}", filename,
                            Thread.CurrentThread.ManagedThreadId);
                        }
                        );
                    }
                    );
            }
            catch (OperationCanceledException ex)
            {
                this.Invoke((Action)delegate
                {
                    this.Text = ex.Message;
                });
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
