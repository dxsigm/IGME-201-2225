// define possible alive states
using System;

public enum EAliveState
{
    alive,
    dead
}

// define possible infected states
public enum EInfectedState
{
    infected,
    vaccinated,
    organic
}

// all neighbors of a cell
public enum EDirection
{
    right,
    down,
    left,
    up,
    topleft,
    topright,
    bottomleft,
    bottomright
}

// use a "by value" structure type to store the current and next state of each cell
public struct StructCellState
{
    // the infected state
    public EInfectedState infectedState;

    // the private alive state in this state structure
    private EAliveState aliveState;

    // a property to apply logic to the infected state based on changing the alive state
    public EAliveState AliveState
    {
        get
        {
            // return the current alive state
            return this.aliveState;
        }

        set
        {
            // update private alive state member
            this.aliveState = value;

            // if the alive state is now dead
            if (this.aliveState == EAliveState.dead)
            {
                // reset the infected state to organic (its original state)
                this.infectedState = EInfectedState.organic;
            }
        }
    }
}

// the Cell class to hold the state of each cell in our organism
public class Cell
{
    // the max # of infected and vaccinated cells we want in our organism
    const int MAX_VIRUSES = 50;
    const int MAX_VACCINES = 50;

    // the number of infected and vaccinated cells in the whole organism
    // static so that these variables are accessible across all Cell objects
    public static int nViruses;
    public static int nVaccines;

    // dynamically calculate how many neighbors each cell has based on the number of directions in EDirection
    public static int MAX_NEIGHBORS = Enum.GetNames(typeof(EDirection)).Length;

    // the array of neighbor cells for this cell
    // create the neighbor array for this cell
    // this needs to be done in the constructor because MAX_NEIGHBORS is calculated at runtime
    public Cell[] neighbor = new Cell[MAX_NEIGHBORS];

    // the next cell to the "right" of this cell.  
    // This allows us to have all our cells in a 1D list which we will use in our recursive method below
    public Cell nextCell;

    // store the current and next cell states using our structures
    // which are "by value" fields and allow using the "=" operator to copy one structure into another
    // note that you need to use Deep or Shallow copying to copy class objects
    // therefore structures can be more efficient storage
    public StructCellState currentCellState;
    public StructCellState nextCellState;

    static Random rand = new Random();

    // the Cell constructor which accepts the total # of cells in the organism 
    // and the probability for a cell to be alive when it is created
    public Cell(int maxCells, int probability = 4)
    {
        // initialize the infected and alive states of the cell
        currentCellState.infectedState = EInfectedState.organic;
        currentCellState.AliveState = EAliveState.dead;

        // calculate probable alive state
        probability = rand.Next(0, probability);

        if (probability == 0)
        {
            // it is alive!
            currentCellState.AliveState = EAliveState.alive;

            if (nViruses < MAX_VIRUSES)
            {
                // calculate a probability of being infected
                if (rand.Next(0, maxCells) < maxCells / MAX_VIRUSES)
                {
                    // it is infected!
                    currentCellState.infectedState = EInfectedState.infected;
                    ++nViruses;
                }
            }

            // if not infected yet and not all vaccines administered yet
            if (currentCellState.infectedState == EInfectedState.organic && nVaccines < MAX_VACCINES)
            {
                // calculate a probability of being vaccinated
                if (rand.Next(0, maxCells) < maxCells / MAX_VACCINES)
                {
                    // it is vaccinated!
                    currentCellState.infectedState = EInfectedState.vaccinated;
                    ++nVaccines;
                }
            }
        }
    }

    public void SetNextState()
    {
        // counters for states of the neighboring cells
        int nAlive = 0;
        int nInfected = 0;
        int nVaccinated = 0;

        // loop through the array of all neighbors
        for (int cntr = 0; cntr < MAX_NEIGHBORS; ++cntr)
        {
            // set a "by reference" variable equal to the current neighbor
            Cell neighborCell = this.neighbor[cntr];

            // if there is a neighbor in this direction
            if (neighborCell != null)
            {
                if (neighborCell.currentCellState.infectedState == EInfectedState.infected)
                {
                    ++nInfected;
                }

                if (neighborCell.currentCellState.infectedState == EInfectedState.vaccinated)
                {
                    ++nVaccinated;
                }

                if (neighborCell.currentCellState.AliveState == EAliveState.alive)
                {
                    ++nAlive;
                }
            }
        }

        nextCellState.infectedState = currentCellState.infectedState;
        nextCellState.AliveState = currentCellState.AliveState;

        if (nAlive < 2 || nAlive > 3)
        {
            nextCellState.AliveState = EAliveState.dead;

        }
        else
        {
            if (nAlive == 3)
            {
                nextCellState.AliveState = EAliveState.alive;
            }
        }

        if (currentCellState.AliveState == EAliveState.alive &&
            nextCellState.AliveState == EAliveState.alive)
        {
            if (nInfected > 0 && nInfected > nVaccinated &&
                currentCellState.infectedState != EInfectedState.vaccinated)
            {
                nextCellState.infectedState = EInfectedState.infected;
            }
            else if (nVaccinated > 0)
            {
                nextCellState.infectedState = EInfectedState.vaccinated;
            }
        }
    }
}
static internal class Program
{
    public static int MAX_ROWS = 30;
    public static int MAX_COLS = 80;

    public static Cell[,] organism = new Cell[MAX_ROWS, MAX_COLS];

    public static bool bExit = false;

    static void Main(string[] args)
    {
        for (int row = 0; row < MAX_ROWS; ++row)
        {
            for (int col = 0; col < MAX_COLS; ++col)
            {
                organism[row, col] = new Cell(MAX_ROWS * MAX_COLS);
            }
        }

        for (int row = 0; row < MAX_ROWS; ++row)
        {
            for (int col = 0; col < MAX_COLS; ++col)
            {
                for (int nCntr = 0; nCntr < Cell.MAX_NEIGHBORS; ++nCntr)
                {
                    Cell neighborCell = null;

                    switch (nCntr)
                    {
                        case (int)EDirection.right:
                            // right neighbor = [row, col + 1]
                            // this also calculates the nextCell to the "right"
                            if (col < MAX_COLS - 1)
                            {
                                neighborCell = organism[row, col + 1];
                                organism[row, col].nextCell = organism[row, col + 1];
                            }
                            else if (row < MAX_ROWS - 1)
                            {
                                organism[row, col].nextCell = organism[row + 1, 0];
                            }
                            break;
                    }
                }
            }
        }
    }
}
