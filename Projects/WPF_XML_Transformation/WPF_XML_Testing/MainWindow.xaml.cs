using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace WPF_XML_Testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void BtnLoadRaw_Click(object sender, RoutedEventArgs e)  // it works
        {
            XMLClasses x_classes = XMLClasses.XMLClassesFromXML("../../../XML2/TechCollege.xml"); // set parents
            XmlSerializer serializer = new XmlSerializer(typeof(XMLClasses));

            StreamReader reader = new StreamReader("../../../XML2/TechCollege.xml"); // todo: choose own xml.xml
            XMLClasses m_sys = (XMLClasses)serializer.Deserialize(reader);

            reader.Close();

            XMLGrid.ItemsSource = m_sys.Students.Student;

            XMLClasses TechCollege = XMLClasses.XMLClassesFromXML2("../../../XML2/TechCollege.xml");

            XMLGrid2.ItemsSource = TechCollege.Classes.Class;
        }
        public void BtnSave_Click(object sender, RoutedEventArgs e) // its alive
        {
            try
            {
                BtnSave.IsEnabled = false;
                XmlSerializer serializer = new XmlSerializer(typeof(XMLClasses));

                StreamReader reader = new StreamReader("../../../XML2/TechCollege.xml");
                XMLClasses m_sys = (XMLClasses)serializer.Deserialize(reader);

                reader.Close();

                m_sys.Students.Student = (List<Student>)XMLGrid.ItemsSource;

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.DefaultExt = "xml";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == true)
                {
                    FileStream fs = (FileStream)saveFileDialog.OpenFile(); // save file
                    serializer.Serialize(fs, m_sys);
                    fs.Close();
                }
                BtnSave.IsEnabled = true;
                SaveText.Text = "Success";
            }
            catch (Exception ex)
            {
                SaveText.Text = "Error: " + ex.Message;
            }
        }

        private string sourceFile = "";
        private string stylesheet = "";

        public void BtnTransform_Click(object sender, RoutedEventArgs e) // transform XSLT and XML
        {
            BtnLoad.IsEnabled = false;
            // Enable XSLT debugging. 
            XslCompiledTransform xslt = new XslCompiledTransform(true);
            // Compile the style sheet.
            xslt.Load(stylesheet);
            // Execute the XSLT transform.

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = "xml";
            saveFileDialog.AddExtension = true;

            if (saveFileDialog.ShowDialog() == true) // this seems jank, but eh
            {
                FileStream fs = (FileStream)saveFileDialog.OpenFile(); // save file
                //FileStream outputStream = new FileStream(saveFileDialog.FileName, FileMode.Create); // Bemærk at Create overskriver!
                xslt.Transform(sourceFile, null, fs);
                fs.Close();
            }
            BtnLoad.IsEnabled = true;
        }

        private void BtnXSLT_Click(object sender, RoutedEventArgs e) // select XSLT file
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                SelectedXSLT.Text = openFileDialog.FileName;
                stylesheet = openFileDialog.FileName;
            }
        }

        private void BtnXML_Click(object sender, RoutedEventArgs e) // select XML file
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                SelectedXML.Text = openFileDialog.FileName;
                sourceFile = openFileDialog.FileName;
            }
        }
        private void BtnLoadResult_Click(object sender, RoutedEventArgs e) // loads transformed xml file
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DataSet dataSet = new DataSet();
            try
            {
                if (openFileDialog.ShowDialog() == true)
                {
                    dataSet.ReadXml(openFileDialog.FileName);
                }
                XMLGrid.ItemsSource = dataSet.Tables[0].DefaultView;
            }
            catch
            {
                MessageBox.Show("Cant show file");
            }
        }

        private string XML_XSD = "";
        private string XSD = "";
        private void BtnValidate_Click(object sender, RoutedEventArgs e) // validate using XML and XSD
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add("TechCollege", XSD);
                settings.ValidationType = ValidationType.Schema;

                XmlReader reader = XmlReader.Create(XML_XSD, settings);
                XmlDocument document = new XmlDocument();
                document.Load(reader);

                ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationEventHandler);

                // the following call to Validate succeeds.
                document.Validate(eventHandler);
                ValidateResult.Text = "Success";
            }
            catch (Exception ex)
            {
                ValidateResult.Text = "Error:" + ex.Message;
            }
        }

        private void BtnXML_XSD_Click(object sender, RoutedEventArgs e) // select XML file for XSD
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                SelectedXML_XSD.Text = openFileDialog.FileName;
                XML_XSD = openFileDialog.FileName;
            }
        }
        private void BtnXSD_Click(object sender, RoutedEventArgs e) // select XSD file
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                SelectedXSD.Text = openFileDialog.FileName;
                XSD = openFileDialog.FileName;
            }
        }

        static void ValidationEventHandler(object sender, ValidationEventArgs e) // XSD validator
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }
        }
    }
}
