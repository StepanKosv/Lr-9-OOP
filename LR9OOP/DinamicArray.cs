using System.Runtime.InteropServices;

namespace Logic;

public class DinamicArray<T>
{
    T[] values;
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Len())
            {
                throw new IndexOutOfRangeException($"index:{index}, len:{Len()}");
            }
            return values[index];
        }
        set
        {
            if (index < 0 || index >= Len())
            {
                throw new IndexOutOfRangeException($"index:{index}, len:{Len()}");
            }
            values[index] = value;
        }
    }
    int ln;
    public DinamicArray(Func<int, T> source, int count):this()
    {
        values = new T[count];
        ln = count;
        for (int i = 0; i < count; i++)
        {
            this[i] = source(i);
        }
    }

    public DinamicArray()
    {
        values=new T[0];
        ln=0;
    }

    public int Len() => ln;
    void Fill(T[] arr)
    {
        for (int i = 0; i < Len(); i++)
        {
            arr[i] = this[i];
        }
    }
    public void Add(T run)
    {
        if (Len() == values.Length)
        {
            T[] newruns = new T[(ln + 1) * 2];
            Fill(newruns);
            this.values = newruns;
        }
        ln++;
        this[Len() - 1] = run;
    }
    public void PopLast(out bool success)
    {
        if (Len() == 0)
        {
            success = false;
            return;
        }
        if (values.Length / 4 >= Len())
        {
            T[] newvals = new T[values.Length / 2];
            Fill(newvals);
            values = newvals;
        }
        ln--;
        success = true;
    }
    public void PopLast(out bool success, out T? val)
    {
        if (Len() == 0)
        {
            success = false;
            val = default(T);
            return;
        }
        val = this[Len() - 1];
        PopLast(out success);
    }
    public bool All(Func<int, T, bool> cond)
    {
        for (int i = 0; i < this.Len(); i++)
        {
            if (!cond(i, this[i])) return false;
        }
        return true;
    }
}