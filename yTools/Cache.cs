﻿using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace yTools
{
    public class Cache
    {
        #region DefaultFolder

        string defaultFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\.cached";

        /// <summary>
        /// Sets the default cache directory as a nested directory in <c>AppData\Local</c>.<br/>
        /// This directory is <c>%LocalAppData%\.cached</c> by default.
        /// It is recommended to change it.
        /// </summary>
        /// <param name="directory">The directory inside AppData\Local to store cache. Use '\' to nest directories.</param>
        public void SetCacheDirectoryInLocalAppData(string directory)
        {
            defaultFolder = directory[0] == '\\'
                ? Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + directory
                : Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + directory;
        }

        /// <summary>
        /// Sets the default cache directory.<br/>
        /// This directory is <c>%LocalAppData%\.cached</c> by default. It is recommended to change it.<br/>
        /// It is recommended to use the Local AppData directory for caching objects; use <see cref="SetCacheDirectoryInLocalAppData(string)"/> instead.
        /// </summary>
        /// <param name="directory">The directory to store cache in. Enter full path including drive.</param>
        public void SetCacheDirectory(string directory)
        {
            defaultFolder = directory;
        }

        #endregion

        #region SaveCache

        /// <summary>
        /// Caches the given object of type T into the given file path.<br/>
        /// Make sure to include all directories, drive and filename in the path.<br/>
        /// Returns true if the caching succeeded. Returns false if an exception was raised.
        /// </summary>
        /// <param name="exception">The exception that occured while running this method. Null if no exception was raised.</param>
        /// <param name="exceptionType">The type of the exception. Null if no exception was raised.</param>
        /// <returns>True if caching succeeded without exception.; false if an exception was raised.</returns>
        public bool SaveCache<T>(string filepath, T obj, out Exception? exception, out Type? exceptionType)
        {
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
        /// Caches the given object of type T into the given file name and parent directory.<br/>
        /// Make sure to include all directories and drive (full path) in the directory.<br/>
        /// Returns true if the caching succeeded. Returns false if an exception was raised.
        /// </summary>
        /// <param name="exception">The exception that occured while running this method. Null if no exception was raised.</param>
        /// <param name="exceptionType">The type of the exception. Null if no exception was raised.</param>
        /// <returns>True if caching succeeded without exception.; false if an exception was raised.</returns>
        public bool SaveCache<T>(T obj, string filename, string directory, out Exception? exception, out Type? exceptionType)
        {
            return SaveCache(directory + @"\" + filename, obj, out exception, out exceptionType);
        }

        /// <summary>
        /// Caches the given object of type T into the given file name inside the default parent directory set by <see cref="SetCacheDirectory(string)"/> or <see cref="SetCacheDirectoryInLocalAppData(string)"/>.<br/>
        /// Returns true if the caching succeeded. Returns false if an exception was raised.
        /// </summary>
        /// <param name="exception">The exception that occured while running this method. Null if no exception was raised.</param>
        /// <param name="exceptionType">The type of the exception. Null if no exception was raised.</param>
        /// <returns>True if caching succeeded without exception.; false if an exception was raised.</returns>
        public bool SaveCacheInDefault<T>(string filename, T obj, out Exception? exception, out Type? exceptionType)
        {
            return SaveCache(obj, filename, defaultFolder, out exception, out exceptionType);
        }

        #endregion

        #region GetCache

        /// <summary>
        /// Returns the cached object of type <see cref="object"/> from the given file path.<br/>
        /// Make sure to include all directories, drive and file name in the path.<br/>
        /// Returns true if the deserialization succeeded. Returns false if an exception was raised.
        /// </summary>
        /// <param name="exception">The exception that occured while running this method. Null if no exception was raised.</param>
        /// <param name="exceptionType">The type of the exception. Null if no exception was raised.</param>
        /// <returns>True if decaching succeeded without exception; false if an exception was raised.</returns>
        public object? GetCache<T>(string filepath, out Exception? exception, out Type? exceptionType)
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
        /// Returns the cached object of type <see cref="object"/> from the given file name and directory.<br/>
        /// Make sure to include all directories and drive in the directory path.<br/>
        /// Returns true if the deserialization succeeded. Returns false if an exception was raised.
        /// </summary>
        /// <param name="exception">The exception that occured while running this method. Null if no exception was raised.</param>
        /// <param name="exceptionType">The type of the exception. Null if no exception was raised.</param>
        /// <returns>True if decaching succeeded without exception; false if an exception was raised.</returns>
        public object? GetCache<T>(string filename, string directory, out Exception? exception, out Type? exceptionType)
        {
            return GetCache<T>(directory + @"\" + filename, out exception, out exceptionType);
        }

        /// <summary>
        /// Returns the cached object of type <see cref="object"/> from the given file name and default directory set by <see cref="SetCacheDirectory(string)"/> or <see cref="SetCacheDirectoryInLocalAppData(string)"/>.<br/>
        /// Make sure to include all directories, drive and file name in the path.<br/>
        /// Returns true if the deserialization succeeded. Returns false if an exception was raised.
        /// </summary>
        /// <param name="exception">The exception that occured while running this method. Null if no exception was raised.</param>
        /// <param name="exceptionType">The type of the exception. Null if no exception was raised.</param>
        /// <returns>True if decaching succeeded without exception; false if an exception was raised.</returns>
        public object? GetCacheFromDefault<T>(string filename, out Exception? exception, out Type? exceptionType)
        {
            return GetCache<T>(defaultFolder + @"\" + filename, out exception, out exceptionType);
        }

        #endregion
    }
}
