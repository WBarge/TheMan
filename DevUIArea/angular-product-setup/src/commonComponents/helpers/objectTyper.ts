

export class ObjectTyper {

    public static NULL: string = "null";
    public static UNDEFINED: string = "undefined";
    public static STRING: string = "String";
    public static ARRAY: string = "Array";
    public static OBJECT: string = "Object";
    public static DONTKNOW: string = "don't know";

    private stringConstructor = "test".constructor;
    private arrayConstructor = [].constructor;
    private objectConstructor = {}.constructor;

    public whatIsIt(o:any):string {

        if (o === null) {
            return ObjectTyper.NULL;// "null";
        }
        else if (o === undefined) {
            return ObjectTyper.UNDEFINED;// "undefined";
        }
        else if (o.constructor === this.stringConstructor) {
            return ObjectTyper.STRING;// "String";
        }
        else if (o.constructor === this.arrayConstructor) {
            return ObjectTyper.ARRAY;// "Array";
        }
        else if (o.constructor === this.objectConstructor) {
            return ObjectTyper.OBJECT;// "Object";
        }
        else {
            return ObjectTyper.DONTKNOW; //"don't know";
        }
    }
}