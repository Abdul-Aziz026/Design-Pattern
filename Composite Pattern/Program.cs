/*
 * Composite pattern : Composite is a structural design pattern that lets you compose objects
 * into tree structures and then work with these structures as if they were individual objects.
 * 
 * Real Life Example
 * File system (Folder > Folder > File)
 * Company structure (CEO > Manager > Employee)
 * UI components (Panel > Panel > Button/TextBox/etc)
 * 
 * 
 * 🎯 Simple Summary
 * Composite = treat single + group the same.
 * 
 * Key roles:
 * Component → common interface
 * Leaf → single object
 * Composite → group of components
 */

public interface IComponent
{
    void Show();
}

public class FileItem : IComponent
{
    private string _name;
    public FileItem(string name)
    {
        _name = name;
    }
    public void Show()
    {
        Console.WriteLine($"File: {_name}");
    }
}

public class Folder : IComponent
{
    private string _name;
    private List<IComponent> _components = new List<IComponent>();
    public Folder(string name)
    {
        _name = name;
    }
    public void AddComponent(IComponent component)
    {
        _components.Add(component);
    }
    public void RemoveComponent(IComponent component)
    {
        _components.Remove(component);
    }
    public void Show()
    {
        Console.WriteLine($"Folder: {_name}");
        foreach (var component in _components)
        {
            component.Show();
        }
    }
}

public class  Program
{
    public static void Main(string[] args)
    {
        var rootFolder = new Folder("Root-Folder");
        var folder1 = new Folder("Sub-Folder");

        IComponent file1 = new FileItem("file1.txt");
        IComponent file2 = new FileItem("file2.txt");
        IComponent file3 = new FileItem("file3.txt");


        rootFolder.AddComponent(folder1);
        rootFolder.AddComponent(file3);

        folder1.AddComponent(file1);
        folder1.AddComponent(file2);

        rootFolder.Show();
    }
}