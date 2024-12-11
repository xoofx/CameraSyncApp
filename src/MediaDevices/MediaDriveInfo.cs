using MediaDevices.Internal;
using System.IO;

namespace MediaDevices
{
    /// <summary>
    /// Provides properties for drives.
    /// </summary>
    public sealed class MediaDriveInfo
    {
        private readonly MediaDevice _device;
        private readonly string _objectId;
        private readonly MediaStorageInfo? _info;

        internal MediaDriveInfo(MediaDevice device, string objectId)
        {
            this._device = device;
            this._objectId = objectId;
            this._info = device.GetStorageInfo(objectId);

            if (this._info != null)
            {
                this.TotalSize = (long)this._info.Capacity;
                this.TotalFreeSpace = this.AvailableFreeSpace = (long)this._info.FreeSpaceInBytes;

                this.DriveFormat = this._info.FileSystemType;

                switch (this._info.Type)
                {
                case StorageType.FixedRam:
                case StorageType.FixedRom:
                    this.DriveType = DriveType.Fixed;
                    break;
                case StorageType.RemovableRam:
                case StorageType.RemovableRom:
                    this.DriveType = DriveType.Removable;
                    break;
                case StorageType.Undefined:
                default:
                    this.DriveType = DriveType.Unknown;
                    break;
                }


                this.RootDirectory = new MediaDirectoryInfo(this._device, Item.Create(this._device, this._objectId));
                this.Name = this.RootDirectory.FullName;
                this.VolumeLabel = this._info.Description;
            }
        }

        /// <summary>
        /// Indicates the available space in bytes.
        /// </summary>
        public long AvailableFreeSpace { get; private set; }

        /// <summary>
        /// Format of the drive.
        /// </summary>
        public string? DriveFormat { get; private set; }

        /// <summary>
        /// Type of the drive
        /// </summary>
        public DriveType DriveType { get; private set; }

        /// <summary>
        /// True is the drive is ready; false if not.
        /// </summary>
        public bool IsReady { get { return true; } }

        /// <summary>
        /// Name of the drive
        /// </summary>
        public string? Name { get; private set; }

        /// <summary>
        /// Get the root directory of the drive.
        /// </summary>
        public MediaDirectoryInfo? RootDirectory { get; private set; }

        /// <summary>
        /// Gets the total free space of the device in bytes.
        /// </summary>
        public long TotalFreeSpace { get; private set; }

        /// <summary>
        /// Gets the total size of the device in bytes.
        /// </summary>
        public long TotalSize { get; private set; }

        /// <summary>
        /// Get the volume lable of the drive.
        /// </summary>
        public string? VolumeLabel { get; private set; }

        /// <summary>
        /// Eject the drive.
        /// </summary>
        public void Eject()
        {
            this._device.InternalEject(this._objectId);
        }

        /// <summary>
        /// Format the drive.
        /// </summary>
        public void Format()
        {
            this._device.Format(this._objectId);
        }
    }
}
