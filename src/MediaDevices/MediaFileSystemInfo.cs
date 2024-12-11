using MediaDevices.Internal;
using System;
using System.Diagnostics;

namespace MediaDevices
{
    /// <summary>
    /// Provides the base class for both MediaFileInfo and MediaDirectoryInfo objects.
    /// </summary>
    [DebuggerDisplay("{FullName}")]
    public abstract class MediaFileSystemInfo
    {
        /// <summary>
        ///corresponding MediaDevice instance
        /// </summary>
        protected readonly MediaDevice Device;

        internal readonly Item Item;

        private MediaDirectoryInfo? _parent;

        internal MediaFileSystemInfo(MediaDevice device, Item item)
        {
            this.Device = device;
            this.Item = item;
            Refresh();
        }

        /// <summary>
        /// Refreshes the state of the object.
        /// </summary>
        public void Refresh()
        {
            this.Item.Refresh();
        }

        /// <summary>
        /// Gets the parent directory of a specified subdirectory.
        /// </summary>
        protected MediaDirectoryInfo? ParentDirectoryInfo
        {
            get
            { 
                if (this._parent == null && this.Item.Parent != null)
                {
                    this._parent = new MediaDirectoryInfo(this.Device, this.Item.Parent);
                }
                return this._parent;
            }
        }

        /// <summary>
        /// Gets the full path of the directory or file.
        /// </summary>
        public string FullName
        {
            get
            {
                return this.Item.FullName!;
            }
        }

        /// <summary>
        /// For files, gets the name of the file. For directories, gets the name of the last directory in the hierarchy if a hierarchy exists. Otherwise, the Name property gets the name of the directory.
        /// </summary>
        public string Name
        {
            get
            {
                return this.Item.Name!;
            }
        }

        /// <summary>
        /// Gets the size, in bytes, of the current file.   
        /// </summary>
        public ulong Length
        {
            get
            {
                return this.Item.Size;
            }
        }

        /// <summary>
        /// Gets the creation time of the current file or directory.
        /// </summary>
        public DateTime? CreationTime
        {
            get
            {
                return this.Item.DateCreated;
            }
            set
            {
                this.Item.SetDateCreated(value.GetValueOrDefault(DateTime.Now));
            }
        }

        /// <summary>
        /// Gets the time when the current file or directory was last written to.
        /// </summary>
        public DateTime? LastWriteTime
        {
            get
            {
                return this.Item.DateModified;
            }
            set
            {
                this.Item.SetDateModified(value.GetValueOrDefault(DateTime.Now));
            }
        }

        /// <summary>
        /// Gets the time when the current file was authored.
        /// </summary>
        public DateTime? DateAuthored
        {
            get
            {
                return this.Item.DateAuthored;
            }
            set
            {
                this.Item.SetDateAuthored(value.GetValueOrDefault(DateTime.Now));
            }
        }

        /// <summary>
        /// Gets the attributes for the current file, directory or object.
        /// </summary>
        public MediaFileAttributes Attributes
        {
            get
            {
                MediaFileAttributes attributes = MediaFileAttributes.Normal;
                switch (this.Item.Type)
                {
                case ItemType.File:
                    attributes = MediaFileAttributes.Normal;
                    break;
                case ItemType.Folder:
                    attributes = MediaFileAttributes.Directory;
                    break;
                case ItemType.Object:
                    attributes = MediaFileAttributes.Object;
                    break;
                }
                attributes |= this.Item.CanDelete ? MediaFileAttributes.CanDelete : 0;
                attributes |= this.Item.IsSystem ? MediaFileAttributes.System : 0;
                attributes |= this.Item.IsHidden ? MediaFileAttributes.Hidden : 0;
                attributes |= this.Item.IsDRMProtected ? MediaFileAttributes.DRMProtected : 0;
                return attributes; 
            }
        }

        /// <summary>
        /// Gets the id of the MTP object.
        /// </summary>
        public string Id
        {
            get
            {
                return this.Item.Id;
            }
        }

        /// <summary>
        /// Gets the persistent unique id of the MTP object.
        /// </summary>
        /// <remarks>
        /// A unique cross session object ID, that is not changing when device is disconnected.
        /// </remarks>
        public string? PersistentUniqueId
        {
            get
            {
                return this.Item.PersistentUniqueId;
            }
        }

        /// <summary>
        /// Rename the folder of file
        /// </summary>
        /// <param name="newName">New name of the file or folder.</param>
        public void Rename(string newName)
        {
            this.Item.Rename(newName);
        }

        /// <summary>
        /// Gets the hash code for the current object.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object? obj)
        {
            return (obj as MediaFileSystemInfo)?.Id == this.Id;
        }
    }
}
