using UnityEngine;

public class Dog : MonoBehaviour, IAnimal
{
    [field: SerializeField] public string Name { get; set; } = "Spot";

    /*
    public Dog(string name) // this is a constuctor
    {
        Name = name;
    }
    */

    private void Start()
    {
        MakeSound();
        Move();
        // IAnimal myDog = new Dog("Spot"); 
        // myDog.MakeSound();
        // myDog.Move();
    }

    public void MakeSound()
    {
        Debug.Log($"{Name} barks when he is happy to see me.");
    }

    public void Move()
    {
        Debug.Log($"{Name} moves when he sees his best friend.");
    }
}
