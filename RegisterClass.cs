/*
(C) 2015 Marcel Garbarczyk m4rcelpl@outlook.com
*/

using Microsoft.Win32;
using System;
using System.Windows;

namespace m4.RegisterClass
{

    public class RegClass
    {

        public bool ViewError { get; set; } = false;
        public bool GetError { get; set; } = false;
        public string ViewErrorTitle { get; set; } = "Register Operation Error";

        public void WriteString(string RootKey, string KeyName, string ValueName, string Value)
        {

            try
            {
                GetError = false;
                Registry.SetValue(RootKey + "\\" + KeyName, ValueName, Value, RegistryValueKind.String);
            }

            catch (Exception e)
            {
                if (ViewError)
                    MessageBox.Show(e.ToString(), ViewErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                GetError = true;
                
            }
        }

        public void WriteExString(string RootKey, string KeyName, string ValueName, string Value)
        {

            try
            {
                GetError = false;
                Registry.SetValue(RootKey + "\\" + KeyName, ValueName, Value, RegistryValueKind.ExpandString);
            }

            catch (Exception e)
            {
                if (ViewError)
                    MessageBox.Show(e.ToString(), ViewErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                GetError = true;
            }
        }

        public void WriteDWord(string RootKey, string KeyName, string ValueName, int Value)
        {

            try
            {
                GetError = false;
                Registry.SetValue(RootKey + "\\" + KeyName, ValueName, Value, RegistryValueKind.DWord);
            }

            catch (Exception e)
            {
                if (ViewError)
                    MessageBox.Show(e.ToString(), ViewErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                GetError = true;
            }
        }

        public void WriteBin(string RootKey, string KeyName, string ValueName, byte[] Value)
        {

            try
            {
                GetError = false;
                Registry.SetValue(RootKey + "\\" + KeyName, ValueName, Value, RegistryValueKind.Binary);
            }

            catch (Exception e)
            {
                if (ViewError)
                    MessageBox.Show(e.ToString(), ViewErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                GetError = true;
            }
        }

        public void WriteMultiString(string RootKey, string KeyName, string ValueName, string[] Value)
        {

            try
            {
                GetError = false;
                Registry.SetValue(RootKey + "\\" + KeyName, ValueName, Value, RegistryValueKind.MultiString);
            }

            catch (Exception e)
            {
                if (ViewError)
                    MessageBox.Show(e.ToString(), ViewErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                GetError = true;
            }
        }

        public void WriteQWord(string RootKey, string KeyName, string ValueName, long Value)
        {

            try
            {
                GetError = false;
                Registry.SetValue(RootKey + "\\" + KeyName, ValueName, Value, RegistryValueKind.QWord);
            }

            catch (Exception e)
            {
                if (ViewError)
                    MessageBox.Show(e.ToString(), ViewErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                GetError = true;
            }
        }


        public string ReadString(string RootKey, string KeyName, string ValueName, string DefaultValu)
        {
            try
            {
                GetError = false;
                return (string)Registry.GetValue(RootKey + "\\" + KeyName, ValueName, DefaultValu);
            }

            catch (Exception e)
            {
                if (ViewError)
                    MessageBox.Show(e.ToString(), ViewErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                GetError = true;

                return DefaultValu;
            }

        }

        public string[] ReadMultiString(string RootKey, string KeyName, string ValueName, string[] DefaultValu)
        {
            try
            {
                GetError = false;
                return (string[])Registry.GetValue(RootKey + "\\" + KeyName, ValueName, DefaultValu);
            }

            catch (Exception e)
            {
                if (ViewError)
                    MessageBox.Show(e.ToString(), ViewErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                GetError = true;

                return DefaultValu;
            }

        }

        public int ReadInt(string RootKey, string KeyName, string ValueName, int DefaultValu)
        {
            try
            {
                GetError = false;
                return (int)Registry.GetValue(RootKey + "\\" + KeyName, ValueName, DefaultValu);
            }

            catch (Exception e)
            {
                if (ViewError)
                    MessageBox.Show(e.ToString(), ViewErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                GetError = true;

                return DefaultValu;
            }

        }

        public byte[] ReadBinary(string RootKey, string KeyName, string ValueName, byte[] DefaultValu)
        {
            try
            {
                GetError = false;
                return (byte[])Registry.GetValue(RootKey + "\\" + KeyName, ValueName, DefaultValu);
            }

            catch (Exception e)
            {
                if (ViewError)
                    MessageBox.Show(e.ToString(), ViewErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                GetError = true;

                return DefaultValu;
            }

        }

        public long ReadInt64(string RootKey, string KeyName, string ValueName, long DefaultValu)
        {
            try
            {
                GetError = false;
                return (long)Registry.GetValue(RootKey + "\\" + KeyName, ValueName, DefaultValu);
            }

            catch (Exception e)
            {
                if (ViewError)
                    MessageBox.Show(e.ToString(), ViewErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                GetError = true;

                return DefaultValu;
            }

        }


        public bool DeleteKey(string RootKey, string KeyName)
        {
            try
            {
                GetError = false;
                if (RootKey == "HKEY_CURRENT_USER")
                {
                    RegistryKey registryK = Registry.CurrentUser;
                    registryK.DeleteSubKeyTree(KeyName);
                }
                if (RootKey == "HKEY_CLASSES_ROOT")
                {
                    RegistryKey registryK = Registry.ClassesRoot;
                    registryK.DeleteSubKeyTree(KeyName);
                }

                if (RootKey == "HKEY_CURRENT_CONFIG")
                {
                    RegistryKey registryK = Registry.CurrentConfig;
                    registryK.DeleteSubKeyTree(KeyName);
                }

                if (RootKey == "HKEY_LOCAL_MACHINE")
                {
                    RegistryKey registryK = Registry.LocalMachine;
                    registryK.DeleteSubKeyTree(KeyName);
                }

                if (RootKey == "HKEY_USERS")
                {
                    RegistryKey registryK = Registry.Users;
                    registryK.DeleteSubKeyTree(KeyName);
                }
                return true;
            }

            catch (Exception e)
            {
                if (ViewError)
                    MessageBox.Show(e.ToString(), ViewErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                GetError = true;

                return false;
            }
        }
        public bool DeleteValue(string RootKey, string KeyName, string ValueName)
        {
            try
            {
                GetError = false;
                if (RootKey == "HKEY_CURRENT_USER")
                {
                    RegistryKey registryK = Registry.CurrentUser;
                    RegistryKey registryKK = registryK.CreateSubKey(KeyName);
                    registryKK.DeleteValue(ValueName);
                }

                if (RootKey == "HKEY_CLASSES_ROOT")
                {
                    RegistryKey registryK = Registry.ClassesRoot;
                    RegistryKey registryKK = registryK.CreateSubKey(KeyName);
                    registryKK.DeleteValue(ValueName);
                }

                if (RootKey == "HKEY_CURRENT_CONFIG")
                {
                    RegistryKey registryK = Registry.CurrentConfig;
                    RegistryKey registryKK = registryK.CreateSubKey(KeyName);
                    registryKK.DeleteValue(ValueName);
                }

                if (RootKey == "HKEY_LOCAL_MACHINE")
                {
                    RegistryKey registryK = Registry.LocalMachine;
                    RegistryKey registryKK = registryK.CreateSubKey(KeyName);
                    registryKK.DeleteValue(ValueName);
                }

                if (RootKey == "HKEY_USERS")
                {
                    RegistryKey registryK = Registry.Users;
                    RegistryKey registryKK = registryK.CreateSubKey(KeyName);
                    registryKK.DeleteValue(ValueName);
                }

                return true;
            }

            catch (Exception e)
            {
                if (ViewError)
                    MessageBox.Show(e.ToString(), ViewErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                GetError = true;

                return false;
            }
        }

    }
  
}