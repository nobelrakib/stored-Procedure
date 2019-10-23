public class ArrayStack implements Stack{
    int size;
    Object [] data;
    
    public ArrayStack(){
        size=0;
        data = new Object[5];
    }
    // The number of items on the stack
    public int size(){
      int j=0;
      for(int i=0;i<data.length;i++){
        if(data[i]!=null) j++;
      }
      return j;
    }
// Returns true if the stack is empty
    public boolean isEmpty(){
      int flag=0;
      for(int i=0;i<data.length;i++){
        if(data[i]!=null) {flag++;break;}
      }
      if(flag ==0)
         return true;
      else return false;
    }
      
// Pushes the new item on the stack, throwing the
// StackOverflowException if the stack is at maximum capacity. It
// does not throw an exception for an "unbounded" stack, which
// dynamically adjusts capacity as needed.
    public void push(Object e) throws StackOverflowException{
      try{
        if(data.length==size){
           throw new StackOverflowException();
        }
      }
        catch(StackOverflowException n){
          System.out.print("stack is oveerflowed");
        }
        data[size]=e;size++;
    }
// Pops the item on the top of the stack, throwing the
// StackUnderflowException if the stack is empty.
    public Object pop() throws StackUnderflowException{
      try{
        if(data.length==0){
           throw new StackUnderflowException();
        }
      }
        catch(StackUnderflowException n){
          System.out.print("stack is underflowed");
        }
        Object k=data[size-1];
        data[size-1]=null;return k;
    }
// Peeks at the item on the top of the stack, throwing
// StackUnderflowException if the stack is empty.
    public Object peek() throws StackUnderflowException{
       try{
        if(data.length==0){
           throw new StackUnderflowException();
        }
      }
        catch(StackUnderflowException n){
          System.out.print("stack is underflowed");
        }
        return(data[size]);
    }
// Returns a textual representation of items on the stack, in the
// format "[ x y z ]", where x and z are items on top and bottom
// of the stack respectively.
    public String toString(){
      String s="";
      for(int i=data.length-1;i>=0;i--){
         s +=i;
      }
      return s;
    }
// Returns an array with items on the stack, with the item on top
// of the stack in the first slot, and bottom in the last slot.
    public Object[] toArray(){
      Object copy[]=new Object[size-1];
      for(int i=0;i<data.length;i++) copy[i]=data[i];
      return copy;
    }
// Searches for the given item on the stack, returning the
// offset from top of the stack if item is found, or -1 otherwise.
    public int search(Object e){
      for(int i=0;i<data.length;i++){
        if(data[i]==e) return (int) e;
      }
      return -2;
    }
    

    
}