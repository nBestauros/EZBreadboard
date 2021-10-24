using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSpawner : MonoBehaviour
{
    // Public GameObjects
    public GameObject resistor;
    public GameObject circuitSwitch;
    public GameObject LEDon;
    public GameObject LED;
    public GameObject Vout5;
    public GameObject Vout4;
    public GameObject Vout3;
    public GameObject Vout2;
    public GameObject Vout1;


    void Start()
    { 
        
        List<string> stringElements = CircuitData.data;
        GameObject[] elements = createElements(stringElements);


        // Gets the initial positions and rotations for each circuit element
        Vector3 location = getInitialPosition(elements[0]);
        Vector3 rotation = getInitialRotation(elements[0]);


        GameObject.Instantiate(elements[0], location, Quaternion.Euler(rotation)); // Instantiates the first element in the list

        int c = 1; // variable to track whether the element series is reversing down the breadboard or not
        bool isReversing = false;
        for (int i = 0; i < elements.Length - 1; i++) // runs through the list of circuit elements
        {
            if (c == 5) // if 5 elements have been placed...
            {
                if (isReversing) 
                {
                    isReversing = false;
                } else
                {
                    isReversing = true; // reverse the series
                }

                c = 1; // reset the reverse counter
            }
            location += getShift(elements[i], elements[i+1], isReversing); // moves the position of the next element to be placed
            GameObject.Instantiate(elements[i+1], location, Quaternion.Euler(getInitialRotation(elements[i+1]))); // instantiate the new circuit element 
            c++; // add to the reverse counter
        }

        placeGroundWire(c, location, elements[elements.Length -1], isReversing); // after the elements have been placed, connect the ending element to ground
    }


    GameObject[] createElements(List<string> stringElements)
    {
        GameObject[] elements = new GameObject[stringElements.Count];

        for (int i = 0; i < stringElements.Count; i++)
        {
            if (stringElements[i] == "Resistor")
            {
                elements[i] = resistor;
            } 
            else if (stringElements[i] == "Switch")
            {
                elements[i] = circuitSwitch;
            } 
            else if (stringElements[i] == "LED")
            {
                elements[i] = LED;
            }
        }

        return elements;
    }
        /* placeGroundWire
         * ---------------
         * This method receives data about the last circuit element to be placed such as its location,
         * its prefab, its location in the reversing series, and if it is reversing. Depending on the
         * type of element and its location in the reversing series, the length of the ground wire
         * will change. Vector3 values have been carefully recorded and calculated to ensure that
         * the ground wire is correctly placed in the breadboard. 
         */
    void placeGroundWire(int c, Vector3 location, GameObject obj, bool isReversing)
    {
        if (c == 1)
        {
            if (obj == resistor) // end is resistor
            {
                location += new Vector3(3.967f, -0.33f, -0.779f);
            } 
            else if (obj == circuitSwitch) // end is switch
            {
                location += new Vector3(4f, 0.007f, -0.897f);
            }
            else if (obj == LED) // end is LED
            {
                location += new Vector3(3.988f, -0.85f, -0.248f);
            }

            GameObject.Instantiate(Vout4, location, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        else if (c == 2)
        {
            if (!isReversing)
            {
                if (obj == resistor) // end is resistor
                {
                    location += new Vector3(3.243f, -0.33f, -0.766f);
                }
                else if (obj == circuitSwitch) // end is switch
                {
                    location += new Vector3(3.302f, 0.007f, -0.916f);
                }
                else if (obj == LED) // end is LED
                {
                    location += new Vector3(3.209f, -0.85f, -0.297f);
                }
                GameObject.Instantiate(Vout3, location, Quaternion.Euler(new Vector3(0, 0, 0)));
            } 
            else if (isReversing)
            {
                if (obj == resistor) // end is resistor
                {
                    location += new Vector3(1.7669f, -0.33f, -0.733f);
                }
                else if (obj == circuitSwitch) // end is switch
                {
                    location += new Vector3(1.785f, 0.007f, -0.9f);
                }
                else if (obj == LED) // end is LED
                {
                    location += new Vector3(1.701f, -0.85f, -0.236f);
                }
                GameObject.Instantiate(Vout1, location, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
        }
        else if (c == 3)
        {
            if (obj == resistor) // end is resistor
            {
                location += new Vector3(2.502f, -0.33f, -0.746f);
            }
            else if (obj == circuitSwitch) // end is switch
            {
                location += new Vector3(2.545f, 0.007f, -0.922f);
            }
            else if (obj == LED) // end is LED
            {
                location += new Vector3(2.442f, -0.85f, -0.267f);
            }

            GameObject.Instantiate(Vout2, location, Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        else if (c == 4)
        {
            if (!isReversing)
            {
                if (obj == resistor) // end is resistor
                {
                    location += new Vector3(1.7669f, -0.33f, -0.733f);
                }
                else if (obj == circuitSwitch) // end is switch
                {
                    location += new Vector3(1.785f, 0.007f, -0.9f);
                }
                else if (obj == LED) // end is LED
                {
                    location += new Vector3(1.701f, -0.85f, -0.236f);
                }
                GameObject.Instantiate(Vout1, location, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (isReversing)
            {
                if (obj == resistor) // end is resistor
                {
                    location += new Vector3(3.243f, -0.33f, -0.766f);
                }
                else if (obj == circuitSwitch) // end is switch
                {
                    location += new Vector3(3.302f, 0.007f, -0.916f);
                }
                else if (obj == LED) // end is LED
                {
                    location += new Vector3(3.209f, -0.85f, -0.297f);
                }
                GameObject.Instantiate(Vout3, location, Quaternion.Euler(new Vector3(0, 0, 0)));
            }

        }
        else if (c == 5)
        {
            if (!isReversing)
            {
                if (obj == resistor) // end is resistor
                {
                    location += new Vector3(0.97699f, -0.33f, -0.726f);

                }
                else if (obj == circuitSwitch) // end is switch
                {
                    location += new Vector3(1.002f, 0.007f, -0.849f);
                }
                else if (obj == LED) // end is LED
                {
                    location += new Vector3(0.989f, -0.883f, -0.228f);
                }
                GameObject.Instantiate(Vout2, location, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else if (isReversing)
            {
                if (obj == resistor) // end is resistor
                {
                    location += new Vector3(3.967f, -0.33f, -0.779f);
                }
                else if (obj == circuitSwitch) // end is switch
                {
                    location += new Vector3(4f, 0.007f, -0.897f);
                }
                else if (obj == LED) // end is LED
                {
                    location += new Vector3(3.988f, -0.85f, -0.248f);
                }
                GameObject.Instantiate(Vout4, location, Quaternion.Euler(new Vector3(0, 0, 0)));
            }

        } 
    }

        /* getInitialPosition
         * ------------------
         * This method returns the Vector3 value of the element when it is the first
         * element in the list. The coordinate points of the starting node in the
         * breadboard differ from element to element so this method returns the 
         * meausred values. 
         */
    Vector3 getInitialPosition(GameObject obj)
    {
        Vector3 location;

        if (obj == resistor)
        {
            location = new Vector3(-10.97f, -0.5f, 15.14f);
        }
        else if (obj == circuitSwitch)
        {
            location = new Vector3(-10.984f, -0.837f, 15.792f);
        }
        else if (obj == LED)
        {
            location = new Vector3(-10.978f, 0.02f, 15.654f);
        }
        else
        {
            location = new Vector3(0, 0, 0);
        }

        return location;
    }

        /* getInitialRotation
         * ------------------
         * This method returns the Vector3 value of the correct rotational orientation
         * for the element in the breadboard. Assets we made in Blender did not have the
         * correct orientation when importing to Unity so this method correctly orients
         * the elements. 
         */
    Vector3 getInitialRotation(GameObject obj)
    {
        Vector3 rotation;

        if (obj == resistor)
        {
            rotation = new Vector3(0, 90, 0);
        }
        else if (obj == circuitSwitch)
        {
            rotation = new Vector3(0, 90, 0);
        }
        else if (obj == LED)
        {
            rotation = new Vector3(0, 0, 0);
        }
        else
        {
            rotation = new Vector3(0, 0, 0);
        }

        return rotation;
    }

         /* getShift
         * ---------
         * This method returns the Vector3 value of the correct movements in the
         * x, y, x plane. The values for a shift determine on whether the element
         * series is reversing, the physical dimensions of the elements, and the
         * amount of nodes the elements take up. Values were measured and calculated
         * to ensure that every circuit element corresponds to the correct hole in
         * the breadboard.
         */
    Vector3 getShift(GameObject obj1, GameObject obj2, bool isReversing)
    {
        if (obj1 == resistor && obj2 == resistor) // resistor to resistor
        {
            if (isReversing)
            {
                return new Vector3(-0.753f, -0, -1.535f);
            } else
            {
                return new Vector3(0.753f, -0, -1.535f);
            }
        }
        else if (obj1 == resistor && obj2 == circuitSwitch) // resistor to switch
        {
            if (isReversing)
            {
                return new Vector3(-0.703f, -0.37f, -0.869f);
            }
            else
            {
                return new Vector3(0.703f, -0.37f, -0.869f);
            }
        }
        else if (obj1 == circuitSwitch && obj2 == circuitSwitch) // switch to switch
        {
            if (isReversing)
            {
                return new Vector3(-0.758f, 0, -1.016f);
            }
            else
            {
                return new Vector3(0.758f, 0, -1.016f);
            }
        }
        else if (obj1 == circuitSwitch && obj2 == resistor) // switch to resistor
        {
            if (isReversing)
            {
                return new Vector3(-0.75f, 0.37f, -1.679f);
            }
            else
            {
                return new Vector3(0.75f, 0.37f, -1.679f);
            }
        }
        else if (obj1 == LED && obj2 == LED) // LED to LED
        {
            if (isReversing)
            {
                return new Vector3(-0.76f, 0, -0.52f);
            }
            else
            {
                return new Vector3(0.76f, 0, -0.52f);
            }
        }
        else if (obj1 == resistor && obj2 == LED) // resistor to LED
        {
            if (isReversing)
            {
                return new Vector3(-0.795f, 0.52f, -0.995f);
            }
            else
            {
                return new Vector3(0.795f, 0.52f, -0.995f);
            }
        }
        else if (obj1 == circuitSwitch && obj2 == LED) // switch to LED
        {
            if (isReversing)
            {
                return new Vector3(-0.668f, 0.857f, -1.157f);
            }
            else
            {
                return new Vector3(0.846f, 0.857f, -1.157f);
            }
        }
        else if (obj1 == LED && obj2 == circuitSwitch) // LED to switch
        {
            if (isReversing)
            {
                return new Vector3(-0.668f, -0.857f, -0.406f);
            }
            else
            {
                return new Vector3(0.668f, -0.857f, -0.406f);
            }
        }
        else if (obj1 == LED && obj2 == resistor) // LED to resistor
        {
            if (isReversing)
            {
                return new Vector3(-0.761f, -0.52f, -1.006f);
            }
            else
            {
                return new Vector3(0.761f, -0.52f, -1.006f);
            }
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }
}
