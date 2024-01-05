
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
    if (todo.Count() == 0)
    {
        ShowEmptyTodoMessage();
        return;
    }
    SeeAllTodo();
}

void AddTodo()
{
    string desc;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        desc = Console.ReadLine();
    }
    while (!IsDescValid(desc));
    todo.Add(desc);
}

bool IsDescValid(string desc)
{
    if (desc == "")
    {
        Console.WriteLine("The description cannot be empty.");
        return false;
    }
    if (todo.Contains(desc))
    {
        Console.WriteLine("The description must be unique.");
        return false;
    }
    return true;

}

void ShowEmptyTodoMessage()
{
    Console.WriteLine("No TODOs have been added yet");
}

void RemoveTodo()
{

    if (todo.Count() == 0)
    {
        ShowEmptyTodoMessage();
        return;
    }

    int index;
    do
    {
        Console.WriteLine("please input index to remove a todo");
        SeeAllTodo();

    } while (!IsIndexValid(out index));

    int todoIndex = index - 1;
    Console.WriteLine("Todo removed:" + todo[todoIndex]);
    todo.RemoveAt(todoIndex);

}

bool IsIndexValid(out int index)
{

    var input = Console.ReadLine();
    if (input == "")
    {
        Console.WriteLine("Selected index cannot be empty.");
        index = 0;
        return false;

    }
    if (int.TryParse(input, out index) && index >= 1 && index <= todo.Count())
    {

        return true;

    }
    Console.WriteLine("The given index is not valid.");
    return false;

}

void SeeAllTodo()
{
    for (int i = 0; i < todo.Count(); ++i)
    {
        Console.WriteLine($"{i + 1}. {todo[i]}");
    }
}