using System;
class HelloWorld {
static string produceSelect()
{
	Console.WriteLine("please enter the column you would like to select on, inputing -1 will stop asking you for new columns");
	Console.WriteLine("you can also define if you want to rename the variable here");
	bool new_column = true;
	string select_statment = "";
	string next_column = " ";
	string[] aggregete_functions = {"count(", "min(", "max(", "sum(", "avg("};
	int aggreagte = 0;
	string final = "select ";
	while(new_column)
	{
		Console.WriteLine("Please enter a column");
		next_column = Console.ReadLine();
		if(next_column == "-1" && select_statment != " ")
		{
		    select_statment = select_statment.Substring(0,(select_statment.Length - 2));
			  return final =final + select_statment;
		}
		else if(next_column == "-1")
		{
			continue;
		}
		if(next_column == "*" && select_statment != " ")
		{
			Console.WriteLine("you cannot use * when you have already defined columns to select on");
			continue;
		}

		Console.WriteLine("Would you like this column to be an aggreagte function? if so, enter a number from the list below or -1 to just be a normal column");
		aggreagte = Convert.ToInt32(Console.ReadLine());

		if(aggreagte != -1 && aggreagte < 6)
		{
			next_column = aggregete_functions[aggreagte - 1] + next_column + ") AS " + next_column;
		}

		select_statment = select_statment  + next_column + ", ";
	}
	return select_statment = " ";

}

static string produceTable()
{
	Console.WriteLine("here you can define the table you want to use, you must include at least one");
	bool new_table = true;
	string select_table = "";
	string next_table = " ";
	
	string final = "from ";
	
	while(new_table)
	{
		Console.WriteLine("Please enter a table name or -1 to quite.");
		next_table = Console.ReadLine();
		if(next_table == "-1" && select_table != " ")
		{
			return final = final + select_table;
		}
		else if(next_table == "-1")
		{
			continue;
		}
			

		select_table = select_table + next_table  +", " ;
	}
	return select_table = " ";
}

static string produceWhere()
{
	Console.WriteLine("here you can define the where clause you want to use, you must include at least one, enter -1 to quit");
	bool new_where = true;
	string select_where = "";
	string next_where = " ";
	string final = "where ";
	string[] where_equalities = {">", "<", ">=", "<=", "==", "like"};
	string[] where_keywords = {"and", "or", "between"};
	int clause = 0;
	string compare=" ";
	while(new_table)
	{
		Console.WriteLine("Please enter a name you would like a where clause for.");
		next_table = Console.ReadLine();
		if(next_table == "-1")
		{
			return final = final + select_table;
		}

		Console.WriteLine("Please enter the equality you would like to use for this clause.");
		
		
		clause = Convert.ToInt32(Console.ReadLine());
		
		next_where = next_where + " " + where_equalities[clause-1];

		Console.WriteLine("Please enter the numbers /string you would like to compare to");
		compare = Console.ReadLine();

		next_where = next_where + " " compare;
	
		Console.WriteLine("Please enter a number for the keyword for the next compare or -1 to stop adding clauses");
		clause = Convert.ToInt32(Console.ReadLine());

		if(clause = -1)
		{
			return final + select_where + next_where;
		}

		else
		{
			next_where + where_keywords[clause-1];
		}

		select_where = select_where + next_where;
	}
	return select_where = " ";
}
  static void Main() {
      string query = " ";
      query = produceSelect();
      query = query +"\n";
      query = query + produceTable() + "\n";
      Console.WriteLine(query);
  }
}



