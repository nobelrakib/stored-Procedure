/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication1;

import java.util.*;
import java.io.*;
import java.util.LinkedList;
import java.util.Queue;
import java.util.Stack;
public class JavaApplication1 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) 
    {
        BufferedReader obj = null;
    int graph [][];
    try{
    FileReader f = new FileReader("C:\\Users\\User\\Desktop\\input.txt");
    obj = new BufferedReader(f);
    String str;
    str = obj.readLine();
    int vertices = Integer.parseInt(str);
    System.out.println("The number of vertices are "+ vertices);
    graph =new int [vertices][vertices];
    while((str = obj.readLine())!= null){
     StringTokenizer st = new StringTokenizer(str," ");
     int token1=0;
     int token2=0;
     while(st.hasMoreTokens())
     {
         token1 = Integer.parseInt(st.nextToken());
         token2 = Integer.parseInt(st.nextToken());
     }
    graph[token1][token2]=1;
    //graph[token2][token1]=1;
    }
    System.out.println("Now the adjacency matrix is:-");
    for(int i=0;i<vertices;i++){
        for(int j=0;j<vertices;j++){
        System.out.print(graph[i][j]+" ");
        }
        System.out.println();
    }
    System.out.println("Now its time for BFS Traversal");
//    String [] color = new String[vertices];
//    int [] parent = new int[vertices];
//    int [] level = new int[vertices];
//    for(int i=0;i<vertices;i++){
//    color [i] = "White";
//    parent[i] = -1;
//    level [i] = -1;
//    }
//    Queue <Integer> q = new LinkedList<>();
//    int s = 0;
//    int u = 0;
//    color [s]="Gray";
//    parent [s]=-1;
//    level [s]=0;
//    q.add(s);
//    while(q.size()!=0){
//    u = q.remove();
//    System.out.print(u+" ");
//    for(int i=0;i<vertices;i++){
//    if(graph[u][i]==1){
//    if(color[i]=="White"){
//    color[i]="Gray";
//    parent[i]=u;
//    level[i]=level[u]+1;
//    q.add(i);
//    }
//    }
//    }
//     color[u]="Black";
//    }
    
    System.out.println("Now its time for DFS Traversal");
    boolean [] visited = new boolean[6];
    int count = 0;
    for(int i = 0; i < graph.length; i++) {
        if(!visited[i]) {   
            dfs(i,graph,visited);    
        }
    }
   
    
    
    System.out.println("Now its time for topsort Traversal");
    boolean [] visited2 = new boolean[6];
    Stack <Integer> s = new Stack<>();
    for(int i = 0; i < graph.length; i++) {
        if(!visited2[i]) {   
            topsort(i,graph,visited2,s);    
        }
    }
    
    
      while(!s.empty())
      {
        System.out.println(s.peek()+" ");
        s.pop();
      }
    
    }
    
    catch(IOException e){ 
    e.printStackTrace();
    }  
    
    
  }
    public static void dfs(int i, int[][] graph, boolean[] visited) {
    if(!visited[i]){        
        visited[i] = true; // Mark node as "visited"
        System.out.print(i+ " ");

        for (int j = 0; j < graph[i].length; j++) {
            if (graph[i][j]==1 && !visited[j]) {
               
                dfs(j, graph, visited); // Visit node
            }
        }
    }   
   }
    
    public static void topsort(int i, int[][] graph, boolean[] visited,Stack<Integer> s) {
    if(!visited[i]){        
        visited[i] = true; // Mark node as "visited"
        

        for (int j = 0; j < graph[i].length; j++) {
            if (graph[i][j]==1 && !visited[j]) {
               
                topsort(j, graph, visited,s); // Visit node
            }
        }
        s.push(i);
    }   
   }
    
}
