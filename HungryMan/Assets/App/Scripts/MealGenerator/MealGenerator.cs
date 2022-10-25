using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SOG.Player
{
  public class MealGenerator : MonoBehaviour
  {
    #region Variables

    [SerializeField] private GameObject[] Meals;

    [SerializeField] private float frequency;

    private List<GameObject> mealList;

    private IEnumerator instantiateMeal;

    #endregion

    private IEnumerator InstantiateMeal()
    {
      for (int i = 0; i < Meals.Length; i++)
      {
        GameObject instantiateObject = Instantiate(Meals[i], new Vector3(0, 0, 0), Quaternion.identity, transform);
        instantiateObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        instantiateObject.SetActive(false);
        mealList.Add(instantiateObject);
        yield return new WaitForSeconds(0.05f);
      }
    }

    private void GenerateMeal()
    {
      if (mealList.Count == 0)
      {
        return;
      }
      GameObject meal = mealList[Random.Range(0, mealList.Count)];
      meal.transform.position = new Vector3(Random.Range(-10f, 10f), transform.position.y, 0);
      meal.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
      meal.SetActive(true);
      mealList.Remove(meal);
    }

    private void Start()
    {
      instantiateMeal = InstantiateMeal();
      mealList = new List<GameObject>();
      StartCoroutine(instantiateMeal);
      InvokeRepeating("GenerateMeal", 0.5f, 2f);
    }
  }
}

