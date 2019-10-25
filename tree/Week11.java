public class Week11{
  public static Node buildTree(Object[]a,int i){
    if(i<=a.length-1 && a[i]!=null){
      return new Node(a[i],buildTree(a,2*i),buildTree(a,2*i+1));
    }else{
      return null;
    }
  }
  public static void printInOrder(Node root){
    if(root==null){}
    else{
      printInOrder(root.left);
      System.out.println(root.val);
      printInOrder(root.right);
    }
  }
   public static void k(Node root){
    if(root==null){}
    else{
       
      k(root.left);
      k(root.right);
      System.out.println(root.val);
    }
  }
  public static int countnode(Node root,int i){
    if(root==null){
    return i-1;}
    else{
      
     int left= countnode(root.left,i+1);
      int right=countnode(root.right,left+1);
      //System.out.println("left "+left+"right "+right);
      if(left==right)return left;
      else if(right>left) return right;
      else return left;
    }
  }
   public static int height(Node root,int i){
    if(root==null){
    return i-1;}
    else{
      
     int left= height(root.left,i+1);
      int right=height(root.right,i+1);
      //System.out.println("left "+left+"right "+right);
      if(left==right)return left;
      else if(right>left) return right;
      else return left;
    }
  }
   public static int level(Node root,int i,int k){
    if(root==null){
    return -1;}
    else{
      
     int left= level(root.left,i+1,k);
     if((int)root.val==k) return i;
      int right=level(root.right,i+1,k);
      //System.out.println("left "+left+"right "+right);
      if(left>0)return left;
      else if(right>0) return right;
      else return -1;
    }
  }
    public static Node copy(Node root){
    if(root==null){
    return null;
    } 
    else{
      Node root1=new Node(root.val,null,null); 
      root1.left=copy(root.left);
      root1.right=copy(root.right);
      //System.out.println(root.val);
      return root1;
    }
  }
     public static boolean checksame(Node root1,Node root2 ){
    if(root1==null && root2==null){
      return true;
      }
    else if(root1==null || root2==null) return false;
    //return root1.val==root2.val;
    boolean k=checksame(root1.left,root1.left);
    boolean k1=checksame(root1.right,root1.right);
    if(k==false || k1==false) return false;
    else {if(root1.val!=root2.val) return false;}
    return true;
    
    }
  
  public static void main(String[]args){
    Object[]array={null,50,25,75,10,30,60,90,-5,null,29,null,
      55,70,null,null,null,9,null,null,27,null,null,null,52,57,
    60,null,null,null,null,null,null,null,0,null,null,null
    ,null,null,26,28};
    Object[]array1={null,50,25,75,3,30,60,90,-5,null,29,null,
      55,70,null,null,null,9,null,null,27,null,null,null,52,57,
    60,null,null,null,null,null,null,null,0,null,null,null
    ,null,null,26,28};
    Node root=buildTree(array,1);
    Node root1=buildTree(array,1);
   // Node newnode=copy(root);;
   boolean check=checksame(root,root1);
   System.out.println(check);
   //printInOrder(newnode);
  }
}
