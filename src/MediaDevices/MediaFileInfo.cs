using MediaDevices.Internal;
using System.IO;

namespace MediaDevices
{
    /// <summary>
    /// Provides properties for files, directories and objects.
    /// </summary>
    public class MediaFileInfo : MediaFileSystemInfo
    {
        internal MediaFileInfo(MediaDevice device, Item item) : base(device, item)
        { }

        /// <summary>
        /// Gets an instance of the parent directory.
        /// </summary>
        public MediaDirectoryInfo? Directory
        {
            get
            {
                return this.ParentDirectoryInfo;
            }
        }

        /// <summary>
        /// Copies an existing file to a new file, allowing the overwriting of the existing file.
        /// </summary>
        /// <param name="destFileName">The name of the new file to copy to.</param>
        /// <param name="overwrite">true to allow an existing file to be overwritten; otherwise, false. </param>
        /// <exception cref="System.IO.IOException">An error occurs, or the destination file already exists and overwrite is false. </exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public void CopyTo(string destFileName, bool overwrite = true)
        {
            if (!this.Device.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            using (FileStream file = File.Open(destFileName, overwrite ? FileMode.Create : FileMode.CreateNew))
            {
                using (Stream sourceStream = Item.OpenRead())
                {
                    sourceStream.CopyTo(file);
                }
            }
        }
        
        public void CopyTo(Stream stream)
        {
            if (!this.Device.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            using Stream sourceStream = Item.OpenRead();
            sourceStream.CopyTo(stream);
        }

        public async Task CopyToAsync(Stream stream)
        {
            if (!this.Device.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }

            await using Stream sourceStream = Item.OpenRead();
            await sourceStream.CopyToAsync(stream);
        }
        
        /// <summary>
        /// Copies an icon of an existing file to a new file, allowing the overwriting of the existing file.
        /// </summary>
        /// <param name="destFileName">The name of the new file to copy to.</param>
        /// <param name="overwrite">true to allow an existing file to be overwritten; otherwise, false. </param>
        /// <exception cref="System.IO.IOException">An error occurs, or the destination file already exists and overwrite is false. </exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public void CopyIconTo(string destFileName, bool overwrite = true)
        {
            if (!this.Device.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            using (FileStream file = File.Open(destFileName, overwrite ? FileMode.Create : FileMode.CreateNew))
            {
                using (Stream sourceStream = Item.OpenReadIcon())
                {
                    sourceStream.CopyTo(file);
                }
            }
        }

        /// <summary>
        /// Copies an thumbnail of an existing file to a new file, allowing the overwriting of the existing file.
        /// </summary>
        /// <param name="destFileName">The name of the new file to copy to.</param>
        /// <param name="overwrite">true to allow an existing file to be overwritten; otherwise, false. </param>
        /// <exception cref="System.IO.IOException">An error occurs, or the destination file already exists and overwrite is false. </exception>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public void CopyThumbnail(string destFileName, bool overwrite = true)
        {
            if (!this.Device.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            using (FileStream file = File.Open(destFileName, overwrite ? FileMode.Create : FileMode.CreateNew))
            {
                using (Stream sourceStream = Item.OpenReadThumbnail())
                {
                    sourceStream.CopyTo(file);
                }
            }
        }

        /// <summary>
        /// Creates a read-only FileStream.
        /// </summary>
        /// <returns>A new read-only FileStream object.</returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public Stream OpenRead()
        {
            if (!this.Device.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            return this.Item.OpenRead();
        }

        /// <summary>
        /// Creates a read-only FileStream of the icon.
        /// </summary>
        /// <returns>A new read-only FileStream object.</returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public Stream OpenIcon()
        {
            if (!this.Device.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            return this.Item.OpenReadIcon();
        }

        /// <summary>
        /// Creates a read-only FileStream of the thumbnail.
        /// </summary>
        /// <returns>A new read-only FileStream object.</returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public Stream OpenThumbnail()
        {
            if (!this.Device.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            return this.Item.OpenReadThumbnail();
        }
        /// <summary>
        /// Creates a StreamReader with UTF8 encoding that reads from an existing text file.
        /// </summary>
        /// <returns>A new StreamReader with UTF8 encoding.</returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">path is invalid.</exception>
        /// <exception cref="MediaDevices.NotConnectedException">device is not connected.</exception>
        public StreamReader OpenText()
        {
            if (!this.Device.IsConnected)
            {
                throw new NotConnectedException("Not connected");
            }
            return new StreamReader(this.Item.OpenRead());
        }
    }
}
