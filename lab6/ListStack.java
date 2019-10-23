public class ListStack implements Stack{
    int size;
    Node top;
  
    
    public ListStack(){
        size = 0;
        top = null;
    }
     // The number of items on the stack
    public int size(){
      int j=0;
      for(Node i=top;i !=null;i=i.next){
         j++;
      }
      return j;
    }
// Returns true if the stack is empty
    public boolean isEmpty(){
      
      int flag=0;
       for(Node i=top;i !=null;i=i.next){
         if(i.val !=null){flag++; break;}
       }
       if(flag >0) return false;
       else true;
    }
      
// Pushes the new item on the stack, throwing the
// StackOverflowException if the stack is at maximum capacity. It
// does not throw an exception for an "unbounded" stack, which
// dynamically adjusts capacity as needed.
    public void push(Object e) throws StackOverflowException{
      Node newlist=new Node(e,top);top=newlist;
    }
// Pops the item on the top of the stack, throwing the
// StackUnderflowException if the stack is empty.
    public Object pop() throws StackUnderflowException{
      try{
        if(top==null){
           throw new StackUnderflowException();
        }
      }
        catch(StackUnderflowException n){
          System.out.print("stack is underflowed");
        }
        Node newnode1=top;
        Node newnode=top.next;top=newnode;
        return newnode1;
    }
// Peeks at the item on the top of the stack, throwing
// StackUnderflowException if the stack is empty.
    public Object peek() throws StackUnderflowException{
      try{
        if(top==null){
           throw new StackUnderflowException();
        }
      }
        catch(StackUnderflowException n){
          System.out.print("stack is underflowed");
        }
        //Node newnode1=top;
        //Node newnode=top.next;top=newnode;
        return top;
    }
// Returns a textual representation of items on the stack, in the
// format "[ x y z ]", where x and z are items on top and bottom
// of the stack respectively.
    public String toString(){
      String s="";
      for(Node i=topi !=null;i=i.next){
         s +=i.val;
      }
      return s;
     // return " ";
    }
// Returns an array with items on the stack, with the item on top
// of the stack in the first slot, and bottom in the last slot.
    public Object[] toArray(){
       Object copy[]=new Object[size-1];
      for(Node i=top;i!=null;i=i.next) copy[i]=i.val;
      return copy;
    }
// Searches for the given item on the stack, returning the
// offset from top of the stack if item is found, or -1 otherwise.
    public int search(Object e){
      int count=0;
       for(Node i=topi !=null;i=i.next){
         count++;
      }
       return count;
    }
    
    

}