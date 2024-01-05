
string actionInput;
var todo = new List<string>();


do
{
    Console.WriteLine("Hello! What do you want to do? [S]ee all TODOs [A]dd a TODO [R]emove a TODO [E]xit ");

    actionInput = Console.ReadLine().ToLower();

    switch (actionInput)
    {
        case "s":
            SeeTodo();
            break;
        case "a":
            AddTodo();
            break;
        case "r":
            RemoveTodo();
            break;
        case "e":
            break;
        default:
            break;
    }


} while (actionInput != "e");


void SeeTodo()
{
    for (int i = 0; i < todo.Count(); ++i)
    {
        Console.WriteLine(i + 1 + ". " + todo[i]);
    }
}

void AddTodo()
{

    bool isEmpty;
    bool isDupTodo;

    do
    {
        Console.WriteLine("Enter the TODO description:");
        var newTodo = Console.ReadLine();
        isEmpty = newTodo.Length == 0;
        isDupTodo = todo.Contains(newTodo);
        if (isDupTodo)
        {
            Console.WriteLine("The description must be unique.");


        }
        else if (isEmpty)
        {
            Console.WriteLine("The description cannot be empty.");

        }
        else
        {
            todo.Add(newTodo);
        }
    }
    while (isEmpty || isDupTodo);
}

void RemoveTodo()
{

    if (todo.Count() == 0)
    {
        Console.WriteLine("No TODOs have been added yet");
        return;
    }

    bool isInputValid;
    string removeInput;
    do
    {
        Console.WriteLine("please input index to remove a todo");
        removeInput = Console.ReadLine();
        var isParsingSuccessful = int.TryParse(removeInput, out int index);
        int initIndex = index - 1;
        isInputValid = isParsingSuccessful && -1 < initIndex && initIndex < todo.Count();
        if (removeInput.Length == 0)
        {
            Console.WriteLine("Selected index cannot be empty.");

        }
        else if (!isInputValid)
        {
            Console.WriteLine("The given index is not valid." + initIndex);

        }
        else
        {
            Console.WriteLine("TODO removed:" + todo[initIndex]);
            todo.RemoveAt(initIndex);

        }

    } while (!isInputValid || removeInput.Length == 0);
}