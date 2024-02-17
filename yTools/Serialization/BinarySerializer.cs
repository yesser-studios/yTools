using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace yTools.Serialization
{
    public class BinarySerializer
    {
        #region DefaultFolder

        string defaultFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\.cached";

        /// <summary>
        /// Sets the default serialization directory to a nested directory in <c>AppData\Local</c>.<br/>
        /// This directory is <c>%LocalAppData%\.cached</c> by default.
        /// It is recommended to change it.
        /// </summary>
        /// <param name="directory">The directory inside AppData\Local to store serialized objects. Use '\' to nest directories.</param>
        public void SetSerializationDirectoryInLocalAppData(string directory)
        {
            SetSerializationDirectory(directory[0] == '\\'
                ? Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + directory
                : Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + directory);
        }

        /// <summary>
        /// Sets the default serialization directory.<br/>
        /// This directory is <c>%LocalAppData%\.cached</c> by default. It is recommended to change it.<br/>
        /// It is recommended to use the Local AppData directory for caching objects; use <see cref="SetSerializationDirectoryInLocalAppData(string)"/> instead.
        /// </summary>
        /// <param name="directory">The directory to store serialized objects in. Enter full path including drive.</param>
        public void SetSerializationDirectory(string directory)
        {
            defaultFolder = directory;

            if (!Directory.Exists(defaultFolder))
                Directory.CreateDirectory(defaultFolder);
        }

        #endregion

        #region Serialize

        /// <summary>
        /// Serializes the given object of type T into the given file path in a binary format.<br/>
        /// Make sure to include all directories, drive and filename in the path.<br/>
        /// Returns true if the serialization succeeded. Returns false if an exception was raised.
        /// </summary>
        /// <param name="exception">The exception that occured while running this method. Null if no exception was raised.</param>
        /// <param name="exceptionType">The type of the exception. Null if no exception was raised.</param>
        /// <returns>True if serialization succeeded without exception.; false if an exception was raised.</returns>
        public bool Serialize<T>(string filepath, T obj, out Exception? exception, out Type? exceptionType)
        {
            string? parentDir = Path.GetDirectoryName(filepath);

            if (parentDir == null || !Directory.Exists(parentDir))
                Directory.CreateDirectory(parentDir);

            exception = null;
            exceptionType = null;

            try
            {
                using var stream = new FileStream(filepath, FileMode.Create);
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);

                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                exceptionType = ex.GetType();
                return false;
            }
        }

        /// <summary>
        /// Serializes the given object of type T into the given file name and parent directory.<br/>
        /// Make sure to include all directories and drive (full path) in the directory.<br/>
        /// Returns true if the serialization succeeded. Returns false if an exception was raised.
        /// </summary>
        /// <param name="exception">The exception that occured while running this method. Null if no exception was raised.</param>
        /// <param name="exceptionType">The type of the exception. Null if no exception was raised.</param>
        /// <returns>True if serialization succeeded without exception.; false if an exception was raised.</returns>
        public bool Serialize<T>(T obj, string filename, string directory, out Exception? exception, out Type? exceptionType)
        {
            return Serialize(directory + @"\" + filename, obj, out exception, out exceptionType);
        }

        /// <summary>
        /// Serializes the given object of type T into the given file name inside the default parent directory set by <see cref="SetSerializationDirectory(string)"/> or <see cref="SetSerializationDirectoryInLocalAppData(string)"/>.<br/>
        /// Returns true if the serialization succeeded. Returns false if an exception was raised.
        /// </summary>
        /// <param name="exception">The exception that occured while running this method. Null if no exception was raised.</param>
        /// <param name="exceptionType">The type of the exception. Null if no exception was raised.</param>
        /// <returns>True if serialization succeeded without exception.; false if an exception was raised.</returns>
        public bool SerializeInDefault<T>(string filename, T obj, out Exception? exception, out Type? exceptionType)
        {
            return Serialize(obj, filename, defaultFolder, out exception, out exceptionType);
        }

        #endregion

        #region Deserialize

        /// <summary>
        /// Returns the serialized object of type <see cref="object"/> from the given file path.<br/>
        /// Make sure to include all directories, drive and file name in the path.<br/>
        /// Returns true if the deserialization succeeded. Returns false if an exception was raised.
        /// </summary>
        /// <param name="exception">The exception that occured while running this method. Null if no exception was raised.</param>
        /// <param name="exceptionType">The type of the exception. Null if no exception was raised.</param>
        /// <returns>True if deserialization succeeded without exception; false if an exception was raised.</returns>
        public object? Deserialize<T>(string filepath, out Exception? exception, out Type? exceptionType)
        {
            exception = null;
            exceptionType = null;

            try
            {
                using var stream = File.OpenRead(filepath);
                var formatter = new BinaryFormatter();
                var obj = formatter.Deserialize(stream);

                return obj;
            }
            catch (Exception ex)
            {
                exception = ex;
                exceptionType = ex.GetType();
                return null;
            }
        }

        /// <summary>
        /// Returns the serialized object of type <see cref="object"/> from the given file name and directory.<br/>
        /// Make sure to include all directories and drive in the directory path.<br/>
        /// Returns true if the deserialization succeeded. Returns false if an exception was raised.
        /// </summary>
        /// <param name="exception">The exception that occured while running this method. Null if no exception was raised.</param>
        /// <param name="exceptionType">The type of the exception. Null if no exception was raised.</param>
        /// <returns>True if deserialization succeeded without exception; false if an exception was raised.</returns>
        public object? Deserialize<T>(string filename, string directory, out Exception? exception, out Type? exceptionType)
        {
            return Deserialize<T>(directory + @"\" + filename, out exception, out exceptionType);
        }

        /// <summary>
        /// Returns the serialized object of type <see cref="object"/> from the given file name and default directory set by <see cref="SetSerializationDirectory(string)"/> or <see cref="SetSerializationDirectoryInLocalAppData(string)"/>.<br/>
        /// Make sure to include all directories, drive and file name in the path.<br/>
        /// Returns true if the deserialization succeeded. Returns false if an exception was raised.
        /// </summary>
        /// <param name="exception">The exception that occured while running this method. Null if no exception was raised.</param>
        /// <param name="exceptionType">The type of the exception. Null if no exception was raised.</param>
        /// <returns>True if deserialization succeeded without exception; false if an exception was raised.</returns>
        public object? DeserializeFromDefault<T>(string filename, out Exception? exception, out Type? exceptionType)
        {
            return Deserialize<T>(defaultFolder + @"\" + filename, out exception, out exceptionType);
        }

        #endregion
    }
}
