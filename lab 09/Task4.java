public class Task4 {
    public static void main(String[]args) {
        System.out.print(binary(10));
    }
    public static String binary(int n) {
        if(n<2) {
            return ""+n;
        }
        else {
            return ""+binary(n/2)+n%2;
        }
    }
}