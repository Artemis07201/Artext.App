using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artext.Structures.FileExtension
{
    public class ArtextFile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtextFile"/> class.
        /// </summary>
        /// <param name="RawFileLocation">The location of the file.</param>
        /// <param name="AutoSave">Whether to auto-save the file. If false, please call <see cref="Save"/>
        /// to save all written data.</param>
        public ArtextFile(string RawFileLocation, bool AutoSave = false)
        {
            this.RawFileLocation = RawFileLocation;
            this.AutoSave = AutoSave;
        }

        public string RawFileLocation { get; }

        public bool AutoSave { get; }

        private MemoryStream? RawStream { get; set; }

        private MemoryStream? GetStream()
        {
            if(File.Exists(this.RawFileLocation))
            {
                this.RawStream ??= new();
                return this.RawStream;
            }
            else
            {
                return null;
            }
        }

        private void WriteRaw(byte[] Write)
        {
            MemoryStream? Stream = this.GetStream();
            if(Stream != null)
            {
                Stream.Write(Write, 0, Write.Length);
                if(this.AutoSave)
                {
                    this.Save();
                }
            }
        }

        /// <summary>
        /// Clears the buffer, and clears the file if <see cref="AutoSave"/> is true.
        /// </summary>
        public void Clear()
        {
            this.RawStream = new();
            if(this.AutoSave)
            {
                this.Save();
            }
        }

        /// <summary>
        /// Writes a string to the buffer, and saves if <see cref="AutoSave"/> is true.
        /// </summary>
        /// <param name="Write">The string to write.</param>
        public void WriteString(string Write)
        {
            this.WriteRaw(Encoding.UTF8.GetBytes(Write));
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        public void Save()
        {
            MemoryStream? Stream = this.GetStream();
            if(Stream != null)
            {
                File.WriteAllText(this.RawFileLocation, Encoding.UTF8.GetString(Stream.ToArray()));
            }
        }
    }
}
