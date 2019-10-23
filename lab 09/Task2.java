public class Task2 {
    public static void main(String[]args) {
        System.out.print(fib(5));
    }
    public static int fib(int x) {
        if(x<2) {
            return x;
        }
        else {
            return fib(x-1)+(x-2);
        }
    }
}