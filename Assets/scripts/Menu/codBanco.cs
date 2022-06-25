using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MySql.Data.MySqlClient;
using UnityEngine.SceneManagement;

public class codBanco : MonoBehaviour
{

    MySqlConnection conn = new MySqlConnection("Server = bv1sltfphakbowq0juj2-mysql.services.clever-cloud.com; Database=bv1sltfphakbowq0juj2; Uid=u6eocyeab24ytsce; Pwd=vx2riiLRC5DldpjcLIos;");

    public InputField emailUser;
    public InputField senhaUser;
    public InputField dataNascUser;
    public InputField nome1;
    public InputField nome2;

    string first;
    string second;
    string third;
    string finalBanco;
    string finalNormal;

    public InputField[] InputList;
    private Color colorRed = new Color(236f/255f, 67f/255f, 67f/255f);


    void Start()
    {

    }

    public void Cadastrar()
    {

        bool result = Validate();

        if(result == true){
    
            string email = emailUser.text;
            string senha = senhaUser.text;
            string nick1 = nome1.text;
            string nick2 = nome2.text;

            conn.Open();

            MySqlCommand comando = new MySqlCommand();

            comando.CommandText = "CALL pcr_userAndNickname(@nick1,@nick2,@email,@senha,@data_nasc)";
            comando.Parameters.AddWithValue("@nick1", nick1);
            comando.Parameters.AddWithValue("@nick2", nick2);
            comando.Parameters.AddWithValue("@email", email);
            comando.Parameters.AddWithValue("@senha", senha);
            comando.Parameters.AddWithValue("@data_nasc", finalBanco);

            comando.Connection = conn;

            MySqlDataReader reader = comando.ExecuteReader();

            Debug.Log(reader.Read());


            if(reader.Read())
            {
                Debug.Log("Usuário cadastrado com sucesso");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            else
            {
                Debug.Log("Houve um erro no cadastro do usuário");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
            
        }
        conn.Close();
    }

    public bool Validate()
    {

        foreach(InputField input in InputList)
        {
            input.image.color = Color.white;
        }

        if (string.IsNullOrEmpty(emailUser.text))
        {
            emailUser.image.color = colorRed;
            return false;
        }
        else if (string.IsNullOrEmpty(senhaUser.text))
        {
            senhaUser.image.color = colorRed;
            return false;
        } 
        else if (string.IsNullOrEmpty(dataNascUser.text))
        {
            dataNascUser.image.color = colorRed;
            return false;
        }
        else if (string.IsNullOrEmpty(nome1.text))
        {
            nome1.image.color = colorRed;
            return false;
        } 
        else if (string.IsNullOrEmpty(nome2.text))
        {
            nome2.image.color = colorRed;
            return false;
        }
        else
        {
            return true;
        }

    }

    public void ChangeDate(){

        char[] dataNasc = new char[8];

        string dataNasc1 = dataNascUser.text;
        dataNasc = dataNasc1.ToCharArray();
        
        if (dataNasc.Length == 8){
            first = dataNasc[0].ToString() + dataNasc[1].ToString();
            second = dataNasc[2].ToString() + dataNasc[3].ToString();
            third = dataNasc[4].ToString() + dataNasc[5].ToString() + dataNasc[6].ToString() + dataNasc[7].ToString();

            finalNormal = first +"/"+ second +"/"+ third;
            finalBanco = third +"/"+ second +"/"+ first;

            dataNascUser.text = finalNormal;
        }
    }

    public void LoginButtonSkip()
    {
        conn.Close();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}