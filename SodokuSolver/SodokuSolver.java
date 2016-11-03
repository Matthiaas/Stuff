import java.util.Arrays;
import java.util.LinkedList;

import javax.management.RuntimeErrorException;


public class SodokuSolver {


	
	
	public static int[][] createFromString(String s)
	{
		int[][]soduku;
		
		if(s != "" && s != null)
		{
			soduku =  new int[9][9];
			int a = 0;
			for( int i =  0 ; i < 9; i++ )
			{
				for( int z =  0 ; z < 9; z++ )
				{
					soduku[i][z] = s.charAt(a) - '0' ; 
					a++;
				}
			}
			return soduku;
		}else
		{
			
			throw new RuntimeException("String is null");
			
		}
		
		
		
		
		
		
		
		
	}
	
	public static void main(String[] aghs)
	{
		
		//Exampel 1
		int[][]soduku = createFromString("570000300000010000000000700000060012080300000000000000650000040000900500100200000");
		printSudoku(soduku);
		solve(soduku ,0 );
		printSudoku(soduku);
		
		//Exampel 2
		soduku =  new int[][]
				{
				{5,0,0	,0,3,0	,0,8,0},
				{0,6,0	,4,0,0	,0,0,0},
				{0,0,4	,0,0,9	,3,0,0},
				
				{0,4,5	,0,0,0	,0,0,7},
				{9,0,0	,0,0,5	,0,0,0},
				{0,0,8	,0,0,3	,0,2,0},
				
				{0,0,0	,0,0,0	,9,5,6},
				{0,2,0	,0,0,0	,0,0,0},
				{0,7,0	,0,0,8	,0,1,0},
				};
		printSudoku(soduku);
		solve(soduku ,0 );
		printSudoku(soduku);
		
		
		
	}
	
	public static void test(int[][]soduku)
	{
		System.out.println("--------------------------------------");
		
		
		for( int i =  0 ; i < 9; i++ )
		{
				for( int z =  0 ; z < 9; z++ )
			
				{
					boolean linea[] = getNotHorizontalLine(soduku,i);
					boolean lineb[] = getNotVertiakalLine(soduku,z) ;
					if(lineb == null ||  linea  == null ) System.out.println("NULL");
					else
					System.out.println(getNotOfTreeLines(linea,lineb,getRowOfSquare(soduku,i,z)));
					
				}
				System.out.println();
		}
	}
	
	public static void printSudoku(int[][]soduku)
	{
		System.out.println("Ausgabe");
		for( int i =  0 ; i < 9; i++ )
		{
			if(i == 3 || i == 6)
			{
				for( int f =  0 ; f < 11; f++ )
			
				{
					System.out.print(" -");
					
				}
				System.out.println();
			}
			for( int z =  0 ; z < 9; z++ )
			{
				
				if(z == 3 || z == 6)
					System.out.print(" |");
				if(soduku[i][z]!= 0)
					System.out.print(" "+soduku[i][z]);
				else
					System.out.print(" .");
			}
			System.out.println();
		}
	}


	public static boolean solve (int[][] soduku , int step )
	{		
		if(isSolution(soduku)) return true;
		
		boolean[][] setBack = new boolean[9][9];	
		LinkedList<Integer>[][] solutionCadindate;		
		
		try{
			solutionCadindate = getSolutionCandidatesAndFill(soduku );
		}catch(java.lang.IllegalArgumentException e){ 
			return false;
		}
		int[] a  = findSmallestList(solutionCadindate);
		for( int sc : solutionCadindate[a[0]][a[1]] )
		{
			int back = soduku[a[0]][a[1]];
			soduku[a[0]][a[1]] = sc;

			if(solve(soduku , step+1 ))
			{
				return true;
			}else
			{
				soduku[a[0]][a[1]] = back;				
			}
		}


		return false;
			
	}
	/*
	public static LinkedList<Integer>[][] getSolutionCandidatesAndFill2(int[][] soduku)
	{
		LinkedList<Integer>[][]    solutionCadindate;

		solutionCadindate = new LinkedList[9][9];
		LinkedList<Integer> l = new LinkedList();
		l.add(1);l.add(2);l.add(3);l.add(4);l.add(5);l.add(6);l.add(7);l.add(8);l.add(9);
		for( int i =  0 ; i < 9; i++ )
		{
			for( int z =  0 ; z < 9; z++ )
			{
				if(soduku[i][z] == 0)
					solutionCadindate[i][z]	= (LinkedList<Integer>)l.clone();
			}
		}
		for( int i =  0 ; i < 9; i++ )
		{
			for( int z =  0 ; z < 9; z++ )
			{
				if(soduku[i][z] != 0)
				{
					for( int a =  0 ; a < 9; a++ )
					{
						if(soduku[i][a] == 0 )
							solutionCadindate[i][a].remove((Object)soduku[i][z]);
						if(soduku[a][z] == 0 )
							solutionCadindate[a][z].remove((Object)soduku[i][z]);
					}
					int [] r = getStarts(i,z);
					int starta =r[0],  startb = r[1];
					for(int a = starta; a< 3+starta; a++)
					{
						for(int b= startb; b< 3+startb; b++)
						{
							if(soduku[a][b] == 0 )
								solutionCadindate[a][b].remove((Object)soduku[i][z]);
						}
					}
				}
			}
		}
		
		return solutionCadindate;
	}
	*/
	public static LinkedList<Integer>[][] getSolutionCandidatesAndFill(int[][] soduku)
	{
		LinkedList<Integer>[][]    solutionCadindate;
		

		solutionCadindate = new LinkedList[9][9];

		for( int i =  0 ; i < 9; i++ )
		{
			for( int z =  0 ; z < 9; z++ )
			{
				if( soduku[i][z] ==  0)
				{
					boolean linea[] = getNotHorizontalLine(soduku,i);
					boolean lineb[] = getNotVertiakalLine(soduku,z) ;
					if(lineb == null ||  linea  == null ) throw new IllegalArgumentException();
					solutionCadindate[i][z] = getNotOfTreeLines(linea,lineb,getRowOfSquare(soduku,i,z));
					if(solutionCadindate[i][z].size() == 0) // Keine Zahl möglich
					{				
						throw new IllegalArgumentException();
					}
					
				}
			}
		}

		
		return solutionCadindate;
	}

	
	public static boolean isSolution(int[][] soduku){
		for( int i =  0 ; i < 9 ; i++ )
		{
			boolean[] horr = new boolean[10] , verr = new boolean[10];
			for( int z =  0 ; z < 9 ; z++ )
			{
				if(horr[soduku[i][z]] ) return false;
					horr[soduku[i][z]] = true;
				
				if(verr[soduku[z][i]]) return false;
					verr[soduku[z][i]] = true;
				
				
				if(soduku[i][z] == 0) return false;
			}
		}
		
		
		for( int starta =  0 ; starta < 6; starta+= 3 )
			for( int startb =  0 ; startb < 6; startb+= 3 )
			{
				boolean[] field = new boolean[10];
				for(int i = starta; i< 3+starta; i++)
				{
					for(int z= 0+startb; z< 3+startb; z++)
					{
						if(field[soduku[i][z]] ) return false;
							field[soduku[i][z]] = true;
					}
				}
			}
				
		
		return true;
	}
		
	
	public static int[] findSmallestList(LinkedList<Integer>  [][] list)
	{
		//System.out.println();
		//System.out.println();
		int listsize = Integer.MAX_VALUE;
		int[] result = {0,10};
		for( int i =  0 ; i < 9; i++ )
			for( int z =  0 ; z < 9; z++ )
			{
				
				if(list[i][z] != null){
				//	System.out.println(i +"   " + z);
					if(list[i][z].size() != 0 && list[i][z].size() < listsize)
					{
						listsize = list[i][z].size();
						result[ 0] = i;
						result[ 1] = z;
					}
				}
					
				
			}
		
		return result;
	}
	
	public static LinkedList<Integer> getNotOfTreeLines(boolean[] a, boolean[] b , boolean[] c)
	{
		boolean [] isIn = new boolean [9];
		LinkedList<Integer> result = new LinkedList<Integer>();
		for(int i = 0 ; i< 9; i++)
		{
			if(a[i] == true)
			{
				isIn[i] = true;
				result.add(i);
			}
		}
		for(int i = 0 ; i< 9; i++)
		{
			if(b[i] == true && isIn[i] != true)
			{
				isIn[i] = true;
				result.add(i);
			}
		}
		for(int i = 0 ; i< 9; i++)
		{
			if(c[i] == true && isIn[i] != true)
			{
				isIn[i] = true;
				result.add(i);
			}
		}
		
		boolean[] res = new boolean [9];
		for(int i = 0 ; i< result.size(); i++)
		{
			res[result.get(i)] = true;
		}
		result = new LinkedList<Integer>();
		for(int i = 0 ; i< res.length; i++)
		{
			if(res[i]==false)
				result.add(i+1);
		}


		
		
	 return result ;
		
	}
	public static int[] getStarts(int a, int b){
		int starta = 0, startb = 0;
		if(a < 3 && b < 3)
		{
			starta = 0;
			startb = 0;
		}
		else if(a< 3 && b < 6)
		{
			starta = 0;
			startb = 3;
		}
		else if(a< 3 && b < 9)
		{
			starta = 0;
			startb = 6;
		}
		else if(a < 6 && b < 3)
		{
			starta = 3;
			startb = 0;
		}
		else if(a< 6 && b < 6)
		{
			starta = 3;
			startb = 3;
		}
		else if(a< 6 && b < 9)
		{
			starta = 3;
			startb = 6;
		}
		else if(a < 9 && b < 3)
		{
			starta = 6;
			startb = 0;
		}
		else if(a< 9 && b < 6)
		{
			starta = 6;
			startb = 3;
		}
		else if(a< 9 && b < 9)
		{
			starta = 6;
			startb = 6;
		}
		return new int[] {starta, startb};
	}
	
	public static boolean[] getRowOfSquare(int[][]soduku , int a, int b)
	{
		int starta = 0, startb = 0;
		if(a < 3 && b < 3)
		{
			starta = 0;
			startb = 0;
		}
		else if(a< 3 && b < 6)
		{
			starta = 0;
			startb = 3;
		}
		else if(a< 3 && b < 9)
		{
			starta = 0;
			startb = 6;
		}
		else if(a < 6 && b < 3)
		{
			starta = 3;
			startb = 0;
		}
		else if(a< 6 && b < 6)
		{
			starta = 3;
			startb = 3;
		}
		else if(a< 6 && b < 9)
		{
			starta = 3;
			startb = 6;
		}
		else if(a < 9 && b < 3)
		{
			starta = 6;
			startb = 0;
		}
		else if(a< 9 && b < 6)
		{
			starta = 6;
			startb = 3;
		}
		else if(a< 9 && b < 9)
		{
			starta = 6;
			startb = 6;
		}
		boolean[] x = new boolean[9]; 
		for(int i = starta; i< 3+starta; i++)
		{
			for(int z= 0+startb; z< 3+startb; z++)
			{
				if(soduku[i][z] !=  0)
				{
					x[soduku[i][z]-1] = true;
				}
			}
		}
		
		return x;
	}
	
	public static boolean[] getNotHorizontalLine(int[][]soduku ,int i)
	{
		boolean[] x = new boolean[9]; ;
		for( int z =  0 ; z < 9; z++ )
		{
			if(soduku[i][z] !=  0)
			{
				if(x[soduku[i][z]-1] == true) return null;
					x[soduku[i][z]-1] = true;
			}
		}
		return x;
		
	}
	public static boolean[] getNotVertiakalLine(int[][]soduku , int z)
	{
		
		boolean[] x = new boolean[9]; 
		for( int i =  0 ; i < 9; i++ )
		{
			if(soduku[i][z] !=  0)
			{
				if(x[soduku[i][z]-1] == true) return null;
				x[soduku[i][z]-1] = true;
			}
		}
		return x;
		
	}
	
}
