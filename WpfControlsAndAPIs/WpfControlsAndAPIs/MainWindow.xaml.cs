using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControlsAndAPIs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Be in Ink mode by default.
            this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
            this.inkRadio.IsChecked = true;
            this.comboColors.SelectedIndex = 0;

            PopulateDocument();
            ConfigureGrid();
        }

        private void RadioButtonClicked(object sender, RoutedEventArgs e)
        {
            // Based on which button sent the event, place the InkCanvas in a unique
            // mode of operation.
            switch ((sender as RadioButton).Content.ToString())
            {
                case "Ink Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                break;
                case "Erase Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                break;
                case "Select Mode!":
                    this.myInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                break;
            }
        }

        private void ColorChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected value in the combo box.
            string colorToUse =
            (this.comboColors.SelectedItem as ComboBoxItem).Content.ToString();
            // Change the color used to render the strokes.
            this.myInkCanvas.DefaultDrawingAttributes.Color =
            (Color)ColorConverter.ConvertFromString(colorToUse);
        }

        private void PopulateDocument()
        {
            // Add some data to the List item.
            this.listOfFunFacts.FontSize = 14;
            this.listOfFunFacts.MarkerStyle = TextMarkerStyle.Circle;
            this.listOfFunFacts.ListItems.Add(new ListItem(new
            Paragraph(new Run("Fixed documents are for WYSIWYG print ready docs!"))));
            this.listOfFunFacts.ListItems.Add(new ListItem(
            new Paragraph(new Run("The API supports tables and embedded figures!"))));
            this.listOfFunFacts.ListItems.Add(new ListItem(
            new Paragraph(new Run("Flow documents are read only!"))));
            this.listOfFunFacts.ListItems.Add(new ListItem(new Paragraph(new Run
            ("BlockUIContainer allows you to embed WPF controls in the document!")
            )));
            // Now add some data to the Paragraph.
            // First part of sentence.
            Run prefix = new Run("This paragraph was generated ");
            // Middle of paragraph.
            Bold b = new Bold();
            Run infix = new Run("dynamically");
            infix.Foreground = Brushes.Red;
            infix.FontSize = 30;
            b.Inlines.Add(infix);
            // Last part of paragraph.
            Run suffix = new Run(" at runtime!");
            // Now add each piece to the collection of inline elements
            // of the Paragraph.
            this.paraBodyText.Inlines.Add(prefix);
            this.paraBodyText.Inlines.Add(infix);
            this.paraBodyText.Inlines.Add(suffix);
        }

        private class Auto
        {
            public string CarID { get; set; }
            public string Make { get; set; }
            public string Color { get; set; }
            public string PetName { get; set; }
        }

        private void ConfigureGrid()
        {
            List<Auto> carList = new List<Auto>();
            carList.Add(new Auto() { CarID = "1", Make = "BMW", Color = "Yellow", PetName = "Chuck" });
            carList.Add(new Auto() { CarID = "1", Make = "BMW", Color = "Yellow", PetName = "Chuck" });
            carList.Add(new Auto() { CarID = "1", Make = "BMW", Color = "Yellow", PetName = "Chuck" });

            this.gridInventory.ItemsSource = carList;
            
        }
    }
}
