var recipeApp = new RecipeApp(new RecipeRepository(), new RecipeUserInteraction());
recipeApp.Run();

public class RecipeApp
{

    private readonly IRecipeRepository _recipeRepository;
    private readonly IRecipeUserInteraction _recipeUserInteraction;

    public RecipeApp(RecipeRepository recipeRepository, RecipeUserInteraction recipeUserInteraction)
    {

        _recipeRepository = recipeRepository;
        _recipeUserInteraction = recipeUserInteraction;
    }

    public void Run()
    {
        var allRecipes = _recipeRepository.Read(filepath);
        _recipeUserInteraction.PrintExistingRecipes(allRecipes);
        _recipeUserInteraction.PromptToCreateRecipe();
        var ingredients = _recipeUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipeRepository.write(filePath, allRecipes);
            _recipeUserInteraction.ShowMessage("recipe added");
            _recipeUserInteraction.ShowMessage(recipe.ToString());


        }
        else
        {
            _recipeUserInteraction.ShowMessage("No ingredients have been selected.");
        }

        _recipeUserInteraction.Exit();

    }
}

public interface IRecipeRepository
{

}

public class RecipeRepository : IRecipeRepository
{

}

public interface IRecipeUserInteraction
{
    void ShowMessage(string message);
    void Exit();
}

public class RecipeUserInteraction : IRecipeUserInteraction
{
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void Exit()
    {
        Console.WriteLine("Press any key to console");
        Console.ReadKey();
    }
}

public class Recipe { }