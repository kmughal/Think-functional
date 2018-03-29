namespace pract.Commons {
    using System;

    public delegate R Method<T, R>(T t);
    public delegate R Method<T1, T2, R>(T1 t1, T2 t2);
    public delegate dynamic Middleware<T>(Func<T, dynamic> cont);

}