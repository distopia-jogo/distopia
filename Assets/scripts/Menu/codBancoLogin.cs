using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using UnityEngine.SceneManagement;

public class codBancoLogin : MonoBehaviour
{
    MySqlConnection conn = new MySqlConnection("Server = bv1sltfphakbowq0juj2-mysql.services.clever-cloud.com; Database=bv1sltfphakbowq0juj2; Uid=u6eocyeab24ytsce; Pwd=vx2riiLRC5DldpjcLIos;");

    public InputField emailUser;
    public InputField senhaUser;

    public InputField[] inputList;

    private Color colorRed = new Color(236f/255f, 67f/255f, 67f/255f);

    public Text resultQuery;

    void Start()
    {

    }

    public void Login()
    {
        resultQuery.color = Color.green;
        resultQuery.text = "Carregando...";

        bool result = Validate();

        if(result == true)
        {

            string email = emailUser.text;
            string senha = senhaUser.text;

            conn.Open();
        
            MySqlCommand comando = new MySqlCommand();

            comando.CommandText = "SELECT * FROM tbl_users WHERE email=@email AND senha=@senha";
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senha);

            comando.Connection = conn;
            MySqlDataReader reader = comando.ExecuteReader();


            if(reader.Read())
            {
                conn.Close();
                Debug.Log("Login Válido");
                SceneManager.LoadScene(2);
            }
            else
            {
                resultQuery.color = Color.red;
                resultQuery.text = "Email ou senha inválidos";
                conn.Close();
                Debug.Log("Login Inválido");

            }
        }
    }

    public bool Validate()
    {

        foreach(InputField input in inputList)
        {
            input.image.color = Color.white;
        }

        if(string.IsNullOrEmpty(emailUser.text) && string.IsNullOrEmpty(senhaUser.text))
        {
            resultQuery.color = Color.red;
            resultQuery.text = "Preencha os campos";
            return false;
        } 

        else if (string.IsNullOrEmpty(emailUser.text))
        {
            emailUser.image.color = colorRed;
            resultQuery.color = Color.red;
            resultQuery.text = "Campo email está vazio";
            return false;
        }

        else if (string.IsNullOrEmpty(senhaUser.text))
        {
            senhaUser.image.color = colorRed;
            resultQuery.color = Color.red;
            resultQuery.text = "Campo senha está vazio";
            return false;
        }

        else
        {
            return true;
        }

    }

    public void RegisterButtonSkip()
    {
        conn.Close();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
