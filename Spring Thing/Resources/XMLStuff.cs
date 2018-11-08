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
            SaveFileDialog save = new SaveFileDialog();
            save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            save.FileName = spring.PartNumber + ".xml";
            save.Filter = "XML File (*.xml)|*.xml|All Files (*.*)|*.*";
            if(save.ShowDialog() == true)
            {
                FileStream file = File.Create(save.FileName);
                x.Serialize(file, spring);
                file.Close();
            }

        }
    }
}
