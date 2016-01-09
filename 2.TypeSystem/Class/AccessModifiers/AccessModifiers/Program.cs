
namespace AccessModifiers
{
    public class CanBeVisibleAnywhere
    {
        private class CanBeDeclaredPrivateOnlyAsNested
        {

        }

        protected class CanBeDelcaredProtectedOnlyAsNested
        {

        }

        protected internal class CanBeDeclaredOnlyAsNested
        {

        }

        public int CanBeAccessesAnywhere;
        private int CanBeAccessedOnlyByDefingClass; // implicit modifier
        protected int ForClassAndChildren;
        internal int ForAssemblyLevelAccess;
        protected internal int AsProtectedOrInternal;
    }

    internal class CanBeVisibleByAssemly // implicit modifier
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
