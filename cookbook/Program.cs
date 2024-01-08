using cookbook.Recipes;
using cookbook.Recipes.Ingredients;

var recipeApp = new RecipeApp(new RecipeRepository(), new RecipeUserInteraction(new IngredientsRegister()));
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

        if (ingredients.Count() > 0)
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
    List<Recipe> Read(string filePath);
}

public class RecipeRepository : IRecipeRepository
{
    public List<Recipe> Read(string filePath)
    {
        return new List<Recipe>{
            new Recipe(new List<Ingredient>{
                new WheatFlour(),
                new Butter(),
                new Sugar()
            })
        };
    }
}

public interface IRecipeUserInteraction
{
    void ShowMessage(string message);
    void Exit();

    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();

    IEnumerable<Ingredient> ReadIngredientsFromUser();
}

public class RecipeUserInteraction : IRecipeUserInteraction
{
    private readonly IngredientsRegister _ingredientsRegister;


    public RecipeUserInteraction(IngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
    public void Exit()
    {
        Console.WriteLine("Press any key to console");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes are:");
            var counter = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"******{counter}*****");
                Console.WriteLine(recipe);
                ++counter;
            }
        }
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe! " +
     "Available ingredients are:");

        foreach (var ingredient in _ingredientsRegister.All)
        {
            Console.WriteLine(ingredient);
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool shallStop = false;
        var ingredients = new List<Ingredient>();

        while (!shallStop)
        {
            Console.WriteLine("d an ingredient by its ID, " +
                "or type anything else if finished.");
            var userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int id))
            {
                var selectedIngredient = _ingredientsRegister.GetById(id);
                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }

            }
            else
            {
                shallStop = true;
            }

        }
        return ingredients;
    }
}


public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetById(int id)
    {
        foreach (var ingredient in All)
        {
            if (ingredient.Id == id)
            {
                return ingredient;
            }
        }

        return null;
    }
}
