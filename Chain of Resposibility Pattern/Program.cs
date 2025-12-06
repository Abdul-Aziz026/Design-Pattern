/*
 * Chain of Responsibility Pattern:
 * 
 * 
 */

public interface IHandler
{
    void Handle(string applicationType);
    IHandler SetNext(IHandler handler);
}

public class Handler : IHandler
{
    private IHandler _nextHandler;
    public IHandler SetNext(IHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual void Handle(string applicationType)
    {
        if (_nextHandler != null)
        {
            _nextHandler.Handle(applicationType);
        }
    }
}

public class DeptChairman : Handler {
    public override void Handle(string applicationType)
    {
        if (applicationType == "Course Changes")
        {
            Console.WriteLine("Department Chairman approved the Course Changes application.");
        }
        else
        {
            base.Handle(applicationType);
        }
    }
}


public class Dean : Handler {
    public override void Handle(string applicationType)
    {
        if (applicationType == "New Course Approval")
        {
            Console.WriteLine("Dean approved the New Course Approval application.");
        }
        else
        {
            base.Handle(applicationType);
        }
    }
}

public class Vc : Handler
{     
    public override void Handle(string applicationType)
    {
        if (applicationType == "Program Accreditation")
        {
            Console.WriteLine("Vice Chancellor approved the Program Accreditation application.");
        }
        else
        {
            base.Handle(applicationType);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Setting up the chain of responsibility
        IHandler deptChairman = new DeptChairman();
        IHandler dean = new Dean();
        IHandler vc = new Vc();

        deptChairman.SetNext(dean).SetNext(vc);
        // Sample applications
        string[] applications = { "Course Changes", "New Course Approval", "Program Accreditation", "Other" };
        foreach (var application in applications)
        {
            Console.WriteLine($"\nProcessing application: {application}");
            deptChairman.Handle(application);
            Console.WriteLine();
        }
    }
}