﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using Warp.Tools;

namespace Warp.Sociology
{
    public class Population : WarpBase
    {
        private bool DoAutosave = true;

        #region Paths and names

        private string _Path = "";
        public string Path
        {
            get { return _Path; }
            set
            {
                if (value != _Path)
                {
                    _Path = value;
                    OnPropertyChanged();
                }
            }
        }

        public string FolderPath => Path.Substring(0, Math.Max(Path.LastIndexOf("/"), Path.LastIndexOf("\\")) + 1);

        private string _Name = "";
        [WarpSerializable]
        public string Name
        {
            get { return _Name; }
            set { if (value != _Name) { _Name = value; OnPropertyChanged(); } }
        }
        
        public string ParticlesDir => FolderPath + "particles/";
        public string ParticleTiltsDir => FolderPath + "particletilts/";
        public string ParticleMoviesDir => FolderPath + "particlemovies/";
        public string SpeciesDir => FolderPath + "species/";

        #endregion

        private ObservableCollection<Species> _Species = new ObservableCollection<Species>();
        public ObservableCollection<Species> Species
        {
            get { return _Species; }
            set { if (value != _Species) { _Species = value; OnPropertyChanged(); } }
        }

        private ObservableCollection<DataSource> _Sources = new ObservableCollection<DataSource>();
        public ObservableCollection<DataSource> Sources
        {
            get { return _Sources; }
            set { if (value != _Sources) { _Sources = value; OnPropertyChanged(); } }
        }

        public Population(string path)
        {
            Species.CollectionChanged += Species_CollectionChanged;
            Sources.CollectionChanged += Sources_CollectionChanged;
            PropertyChanged += Population_PropertyChanged;

            if (File.Exists(path))  // Load
                Load(path);
            else
                Path = path;        // Create
        }

        private void Species_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (DoAutosave)
                Save();
        }

        private void Sources_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (DoAutosave)
                Save();
        }

        private void Population_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (DoAutosave)
                Save();
        }

        public void Load(string path)
        {
            DoAutosave = false;

            Path = path;

            using (Stream SettingsStream = File.OpenRead(path))
            {
                XPathDocument Doc = new XPathDocument(SettingsStream);
                XPathNavigator Reader = Doc.CreateNavigator();
                Reader.MoveToRoot();
                Reader.MoveToChild("Population", "");

                ReadFromXML(Reader);

                List<Species> AllSpecies = new List<Species>();
                foreach (XPathNavigator nav in Reader.Select("Species/Species"))
                {
                    Guid SpeciesGUID = Guid.Parse(nav.GetAttribute("GUID", ""));
                    string SpeciesPath = nav.GetAttribute("Path", "");

                    Species LoadedSpecies = Sociology.Species.FromFile(SpeciesPath);
                    if (LoadedSpecies.GUID != SpeciesGUID)
                        throw new Exception("Stored GUID does not match that of the species.");

                    AllSpecies.Add(LoadedSpecies);
                }
                foreach (var species in AllSpecies)
                    species.ResolveChildren(AllSpecies);

                Species.Clear();
                foreach (var toplevel in AllSpecies.Where(s => s.Parent == null))
                    Species.Add(toplevel);

                foreach (XPathNavigator nav in Reader.Select("Sources/Source"))
                {
                    string Path = nav.GetAttribute("Path", "");
                    Guid SourceGUID = Guid.Parse(nav.GetAttribute("GUID", ""));

                    DataSource LoadedSource = DataSource.FromFile(Path);
                    if (SourceGUID != LoadedSource.GUID)
                        throw new Exception("Stored GUID does not match that of the data source.");

                    Sources.Add(LoadedSource);
                }
            }

            DoAutosave = true;
        }

        public void Save()
        {
            XmlTextWriter Writer = new XmlTextWriter(File.Create(Path), Encoding.Unicode);
            Writer.Formatting = Formatting.Indented;
            Writer.IndentChar = '\t';
            Writer.Indentation = 1;
            Writer.WriteStartDocument();
            Writer.WriteStartElement("Population");

            WriteToXML(Writer);

            Species[] AllSpecies = Helper.Combine(Species.Select(s => s.AllDescendants));
            Writer.WriteStartElement("Species");
            foreach (var species in AllSpecies)
            {
                Writer.WriteStartElement("Species");
                XMLHelper.WriteAttribute(Writer, "GUID", species.GUID.ToString());
                XMLHelper.WriteAttribute(Writer, "Path", species.Path);
                Writer.WriteEndElement();
            }
            Writer.WriteEndElement();

            Writer.WriteStartElement("Sources");
            foreach (var source in Sources)
            {
                Writer.WriteStartElement("Source");
                XMLHelper.WriteAttribute(Writer, "GUID", source.GUID.ToString());
                XMLHelper.WriteAttribute(Writer, "Path", source.Path);
                Writer.WriteEndElement();
            }
            Writer.WriteEndElement();

            Writer.WriteEndElement();
            Writer.WriteEndDocument();
            Writer.Flush();
            Writer.Close();
        }
    }
}
