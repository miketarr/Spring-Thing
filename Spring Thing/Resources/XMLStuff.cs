using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Xml;
using System.Xml.Serialization;
using Spring_Thing.Springs;

namespace Spring_Thing.Resources
{
    public class XMLStuff
    {
        public void SaveCompression(Compression spring)
        {
            XmlSerializer x = new XmlSerializer(spring.GetType());
            SaveFileDialog save = new SaveFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                FileName = spring.PartNumber + ".xml",
                Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*"
            };
            if (save.ShowDialog() == true)
            {
                FileStream file = File.Create(save.FileName);
                x.Serialize(file, spring);
                file.Close();
            }

        }

        public Compression ReadCompression()
        {
            Compression openCompression = new Compression();

            XmlSerializer reader = new XmlSerializer(typeof(Compression));
            OpenFileDialog open = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*"
            };
            if (open.ShowDialog() == true)
            {
                FileStream file = File.Open(open.FileName, FileMode.Open);
                openCompression = (Compression)reader.Deserialize(file);
                file.Close();
            }

            return openCompression;
        }
    }
}
