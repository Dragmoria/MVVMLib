using MVVMLib.Data;

namespace MVVMLib.UI.Models;

public class User : IsObservable
{
    private string _firstName;

    public string FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);
    }

    private string _lastName;

    public string LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }

    public User(string firstName, string lastName)
    {
        ArgumentException.ThrowIfNullOrEmpty(firstName);
        ArgumentException.ThrowIfNullOrEmpty(lastName);

        FirstName = firstName;
        LastName = lastName;
    }

    public override string ToString()
    {
        return FirstName + LastName;
    }
}