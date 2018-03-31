namespace FunctionalApp.Commons
{
    using FunctionalApp.Models;

    public class Delegates
    {
        public delegate R AddStudentApply<T1, T2, T3,R>(T1 t1, T2 t2, T3 t3);
    }
}