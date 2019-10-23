public class Task3 {
    public static void main(String[]args) {
        int a[]={1,2,3,4,5,6,7};
        array(a,0);
    }
    public static void array(int a[],int x) {
        System.out.print(a[x]);
        if(x<a.length-1) {
        array(a,x+1);
    }
}
}