# Register Class CSharp

## How to use it
* In **Visual Studio Add** "[RegisterClass.cs"](../master/RegisterClass.cs) in **Solution Explorer**.
* Add 
```C# 
using m4.RegisterClass;
```
and
```C#
RegClass Reg = new RegClass();
```
that all.

## Examples
### Wite
##### Wite String (REG_SZ)

```C#
Reg.WriteString("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Version Name", "Odyn");
```
*(string, string, string, string)*

##### Wite Int32 (REG_DWORD)
```C#
Reg.WriteDWord("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Version Number32", 2);
```
*(string, string, string, int)*

##### Wite Int64 (REG_QWORD)
```C#
Reg.WriteQWord("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Version Number64", 2);
```
*(string, string, string, long)*

##### Wite Extendet String (REG_EXPAND_SZ)
```C#
Reg.WriteExString("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Location", "c:\\Program Files\\My program");
```
*(string, string, string, string)*

##### Wite Multi String (REG_MULTI_SZ)
```C#
Reg.WriteMultiString("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Setting",  new string[]{"bold", "52", "close"} );
```
*(string, string, string, string[])*

##### Wite Binary (REG_BINARY)
```C#
Reg.WriteBin("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Some data", new byte[] {10,10,10});
```
*(string, string, string, byte[])*

### Read
Please note that the last value is default value.

##### Read String (REG_SZ) and Extendet String (REG_EXPAND_SZ)
```c#
MessageBox.Show("Version Name: " + Reg.ReadString("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Version Name", null));
```
```c#
MessageBox.Show("Version Name: " + Reg.ReadString("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Location", null));
```

##### Read Int32 (REG_DWORD)
```c#
MessageBox.Show("Version Number32: " + Reg.ReadInt("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Version Number32", 0));
```
##### Read Int64 (REG_QWORD)
```c#
MessageBox.Show("Version Number64: " + Reg.ReadInt64("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Version Number64", 0));
```

##### Read Multi String (REG_MULTI_SZ)
```c#
string[] Value = Reg.ReadMultiString("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Setting", null);
            string Message = "";
            foreach (string value in Value)
            {
                Message = Message + value + " ";
            }
            MessageBox.Show("Setting: " + Message);
```

##### Read Binary (REG_BINARY)
```c#
byte[] ValueByte = Reg.ReadBinary("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Some data", null);
            string Suma = "";
            foreach (byte value in ValueByte)
            {
                Suma = Suma + value;
            }
            MessageBox.Show("Some data: " + Suma);
```

### Delete
How to remove all the values that we created earlier
```c#
Reg.DeleteValue("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Version Name");
Reg.DeleteValue("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Version Number32");
Reg.DeleteValue("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Version Number64");
Reg.DeleteValue("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Location");
Reg.DeleteValue("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Setting");
Reg.DeleteValue("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Some data");
```
And the whole key
```c#
Reg.DeleteKey("HKEY_CURRENT_USER", "SOFTWARE\\My Program");
```


### Error Handling
If you want to display errors simply turn on `ViewError`:
```c#
Reg.ViewError = true;
```
You can specify name for the window with error by changing `ViewErrorTitle`
```c#
Reg.ViewErrorTitle = "Register Operation Error";
```
This might be helpful in debug. You can change the window name for every operation.
```c#
Reg.ViewErrorTitle = "Write String Operation Error";
Reg.WriteString("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Version Name", "Odyn");

Reg.ViewErrorTitle = "Write DWord Operation Error";
Reg.WriteDWord("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Version Number32", 2);
```

You can add you own error messages based on `GetError` status. `true` = error, `false` = no error (default).
```c#
Reg.WriteString("HKEY_CURRENT_USER", "SOFTWARE\\My Program", "Version Name", "Odyn");
if (Reg.GetError)
{
//Error appeared do what you want
}
```

### Thenks
Thank to **Francesco Natali**, I'm inspired by his works.

http://www.codeproject.com/Articles/3389/Read-write-and-delete-from-registry-with-C

