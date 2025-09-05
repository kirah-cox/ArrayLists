namespace ArrayLists;
class Program
{
    public static void Main()
    {

        var testList1 = new ArrayBasedList();
        var testList2 = new ArrayBasedList();
        var testList3 = new ArrayBasedList();
        var testList4 = new ArrayBasedList();

        Random randomNumber = new Random();

        System.Diagnostics.Stopwatch testList1Time = new System.Diagnostics.Stopwatch();
        System.Diagnostics.Stopwatch testList2Time = new System.Diagnostics.Stopwatch();
        System.Diagnostics.Stopwatch testList3Time = new System.Diagnostics.Stopwatch();
        System.Diagnostics.Stopwatch testList4Time = new System.Diagnostics.Stopwatch();

        testList1Time.Start();
        AddNumbersToList(testList1, 0, randomNumber, 1000);
        testList1Time.Stop();

        testList2Time.Start();
        AddNumbersToList(testList2, 4, randomNumber, 1000);
        testList2Time.Stop();

        testList3Time.Start();
        AddNumbersToList(testList3, 0, randomNumber, 2000);
        testList3Time.Stop();

        testList4Time.Start();
        AddNumbersToList(testList4, 4, randomNumber, 2000);
        testList4Time.Stop();

        Console.WriteLine();
        Console.WriteLine($"Execution time for adding a 1000 numbers to the beginning of a list: {testList1Time.Elapsed.TotalMilliseconds} ms.");
        Console.WriteLine($"Execution time for adding a 1000 numbers to the end of a list: {testList2Time.Elapsed.TotalMilliseconds} ms.");
        Console.WriteLine($"Execution time for adding a 2000 numbers to the beginning of a list: {testList3Time.Elapsed.TotalMilliseconds} ms.");
        Console.WriteLine($"Execution time for adding a 2000 numbers to the end of a list: {testList4Time.Elapsed.TotalMilliseconds} ms.");
        Console.WriteLine();
    }

    public static void AddNumbersToList(ArrayBasedList testList, int index, Random randomNumber, int numberAmount)
    {
        for (int amountOfNumbers = 0; amountOfNumbers < numberAmount; amountOfNumbers++)
        {
            testList.InsertValueAt(randomNumber.Next(1, 10), index);
        }
    }
}

public class ArrayBasedList
{
    private int[] allocated;
    private int numUsed;

    public ArrayBasedList(int initialSize = 5)
    {
        allocated = new int[initialSize];
        numUsed = 0;
    }

    public int GetNumItems()
    {
        return numUsed;
    }

    // assumes there is space to shift
    private void ShiftRightStartAt(int index)
    {
        for (int targetIndex = numUsed; targetIndex > index; targetIndex--)
        {
            allocated[targetIndex] = allocated[targetIndex - 1];
        }
    }

    private void Reallocate()
    {
        int currentSize = allocated.Length;
        int newSize = currentSize < 1 ? 1 : 2 * currentSize;
        int[] newAllocated = new int[newSize];
        Array.Copy(allocated, newAllocated, numUsed);
        allocated = newAllocated;
    }

    public void InsertValueAt(int value, int positionOfNewValue)
    {
        // if no space left, then grow
        if (numUsed == allocated.Length)
        {
            Reallocate();
        }
        ShiftRightStartAt(positionOfNewValue);
        allocated[positionOfNewValue] = value;
        numUsed++;
    }

    public int GetValueAt(int index)
    {
        return allocated[index];
    }

    public void SetValueAt(int value, int position)
    {
        allocated[position] = value;
    }

    public void RemoveValueAt(int index)
    {
        numUsed--;
        for (int targetIndex = index; targetIndex > numUsed; targetIndex++)
        {
            allocated[targetIndex] = allocated[targetIndex + 1];
        }
    }
}