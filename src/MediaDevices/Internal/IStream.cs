// Copyright (c) Alexandre Mutel. All rights reserved.
// Licensed under the BSD-Clause 2 license.
// See license.txt file in the project root for full license information.

using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.Marshalling;

namespace MediaDevices.Internal;

[GeneratedComInterface]
[Guid("0000000c-0000-0000-C000-000000000046")]
[EditorBrowsable(EditorBrowsableState.Never)]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal partial interface IStream : IComObject
{
    /// <summary>Reads a specified number of bytes from the stream object into memory starting at the current seek pointer.</summary>
    /// <param name="pv">When this method returns, contains the data read from the stream. This parameter is passed uninitialized.</param>
    /// <param name="cb">The number of bytes to read from the stream object.</param>
    /// <param name="pcbRead">A pointer to an <see langword="uint" /> variable that receives the actual number of bytes read from the stream object.</param>
    void Read([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1), Out] byte[] pv, int cb, IntPtr pcbRead);

    /// <summary>Writes a specified number of bytes into the stream object starting at the current seek pointer.</summary>
    /// <param name="pv">The buffer to write this stream to.</param>
    /// <param name="cb">The number of bytes to write to the stream.</param>
    /// <param name="pcbWritten">A pointer to a <see langword="uint" /> variable where this method writes the actual number of bytes written to the stream object. The caller can set this pointer to <see cref="F:System.IntPtr.Zero" />, in which case this method does not provide the actual number of bytes written.</param>
    void Write([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] pv, int cb, IntPtr pcbWritten);

    /// <summary>Changes the seek pointer to a new location relative to the beginning of the stream, to the end of the stream, or to the current seek pointer.</summary>
    /// <param name="dlibMove">The displacement to add to <paramref name="dwOrigin" />.</param>
    /// <param name="dwOrigin">The origin of the seek. The origin can be the beginning of the file, the current seek pointer, or the end of the file.</param>
    /// <param name="plibNewPosition">On successful return, contains the offset of the seek pointer from the beginning of the stream.</param>
    void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition);

    /// <summary>Changes the size of the stream object.</summary>
    /// <param name="libNewSize">The new size of the stream as a number of bytes.</param>
    void SetSize(long libNewSize);

    /// <summary>Copies a specified number of bytes from the current seek pointer in the stream to the current seek pointer in another stream.</summary>
    /// <param name="pstm">A reference to the destination stream.</param>
    /// <param name="cb">The number of bytes to copy from the source stream.</param>
    /// <param name="pcbRead">On successful return, contains the actual number of bytes read from the source.</param>
    /// <param name="pcbWritten">On successful return, contains the actual number of bytes written to the destination.</param>
    void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten);

    /// <summary>Ensures that any changes made to a stream object that is open in transacted mode are reflected in the parent storage.</summary>
    /// <param name="grfCommitFlags">A value that controls how the changes for the stream object are committed.</param>
    void Commit(int grfCommitFlags);

    /// <summary>Discards all changes that have been made to a transacted stream since the last <see cref="M:System.Runtime.InteropServices.ComTypes.IStream.Commit(System.Int32)" /> call.</summary>
    void Revert();

    /// <summary>Restricts access to a specified range of bytes in the stream.</summary>
    /// <param name="libOffset">The byte offset for the beginning of the range.</param>
    /// <param name="cb">The length of the range, in bytes, to restrict.</param>
    /// <param name="dwLockType">The requested restrictions on accessing the range.</param>
    void LockRegion(long libOffset, long cb, int dwLockType);

    /// <summary>Removes the access restriction on a range of bytes previously restricted with the <see cref="M:System.Runtime.InteropServices.ComTypes.IStream.LockRegion(System.Int64,System.Int64,System.Int32)" /> method.</summary>
    /// <param name="libOffset">The byte offset for the beginning of the range.</param>
    /// <param name="cb">The length, in bytes, of the range to restrict.</param>
    /// <param name="dwLockType">The access restrictions previously placed on the range.</param>
    void UnlockRegion(long libOffset, long cb, int dwLockType);

    /// <summary>Retrieves the <see cref="T:System.Runtime.InteropServices.STATSTG" /> structure for this stream.</summary>
    /// <param name="pstatstg">When this method returns, contains a <see langword="STATSTG" /> structure that describes this stream object. This parameter is passed uninitialized.</param>
    /// <param name="grfStatFlag">Members in the <see langword="STATSTG" /> structure that this method does not return, thus saving some memory allocation operations.</param>
    void Stat(nint pstatstg, int grfStatFlag);

    /// <summary>Creates a new stream object with its own seek pointer that references the same bytes as the original stream.</summary>
    /// <param name="ppstm">When this method returns, contains the new stream object. This parameter is passed uninitialized.</param>
    void Clone(out IStream ppstm);
}