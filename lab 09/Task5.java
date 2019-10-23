import java.util.Scanner;
public class Task5 {
    public static void main(String []args) {
        Scanner sc=new Scanner(System.in);
        int n=sc.nextInt();
        int m=sc.nextInt();
        System.out.print(power(n,m));
    }
    public static int power(int n,int m) {
        if(m==0) {
            return 1;
        }
        else {
            return n*power(n,m-1);
        }
    }
}

       
 

        