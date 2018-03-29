class MayBe<T>{
    hasValue: boolean;
    constructor(private content: T) {
        this.hasValue = !(!this.content);
    }


    static Some<T>(content: T): MayBe<T> {
        return new MayBe(content);
    }

    static None<T>() { return new MayBe<T>(null); }

    static fromValue<T>(value: T): MayBe<T> {
        return value ? MayBe.Some(value) : MayBe.None();
    }

    public getOrElse(defaultValue: T) {
        return this.content ? this.content : defaultValue;
    }

    public map<R>(f: (wrapped: T) => R): MayBe<R> {
        if (this.hasValue) {
            return MayBe.Some(f(this.content));
        }

        return MayBe.None();
    }
}




class Employee {
    constructor(public id: number, public name: string) {

    }
}


const employees = new Array<Employee>();


function findById(id: number): MayBe<Employee> {
    const result: Employee = employees.find((e: Employee) => e.id === id)[0];
    return result ? MayBe.Some(result) : MayBe.None();
}


findById(1).map((e) => { e.name });



/* Type script monard */