using System.Reflection;

namespace Users.Infrastructure;

public static class AssemblyReference
{
    public static Assembly Assembly = typeof(AssemblyReference).Assembly;
}