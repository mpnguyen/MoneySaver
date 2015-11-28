using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Windows.Data.Xml.Dom;


namespace DataLayer
{
    public class DAO
    {
        public static async Task<XmlDocument> LoadXmlFile(String folder, String file)
        {
            var storageFolder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(folder);
            var storageFile = await storageFolder.GetFileAsync(file);
            var loadSettings = new XmlLoadSettings
            {
                ProhibitDtd = false,
                ResolveExternals = false
            };        
            return await XmlDocument.LoadFromFileAsync(storageFile, loadSettings);
        }

        public async Task<XmlNodeList> GetNodeList(string xpath)
        {
            var doc = await LoadXmlFile("Data", "database.xml");
            var nodeList = doc.SelectNodes(xpath);
            return nodeList;
        }
    }
}
