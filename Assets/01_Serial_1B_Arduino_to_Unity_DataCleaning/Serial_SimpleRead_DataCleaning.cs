using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * �Ʒ��� System.IO.Ports�� ����ϱ� ���ؼ���
 * Unity Editor > Edit > Project Settings > Player > Other Settings > Configuration > Api Compatibility Level��
 * .NET 4.x�� �����ϰ� Unity Editor�� �ٽ� �����ؾ� �� * 
 */
using System.IO.Ports;

using System; // catch exception ó���� ���� ���

/*
Arduino Code
------------- 
int value = 0;
void setup() {
  Serial.begin(9600);
}

void loop() {
  Serial.print(value);
  Serial.println();
  delay(1000);
  value++;
}
------------- 
*/

public class Serial_SimpleRead_DataCleaning : MonoBehaviour
{
    /// <summary>
    /// �ø��� ����� ����ϴ� arduino ��ü ����
    /// </summary>
    SerialPort arduino;

    /// <summary>
    /// �ø��� ��Ʈ
    /// </summary>
    public string portName = "COM5";

    /// <summary>
    /// �Ƶ��̳밡 ������ �����͸� �����ϴ� sting ����
    /// </summary>
    public string serialIn;

    // Start is called before the first frame update
    void Start()
    {
        ///
        // PC�� Ȱ��ȭ�� �ø��� ��Ʈ�� ��� ����
        ///
        string[] ports = SerialPort.GetPortNames();

        ///
        // ports �迭 �ȿ� �ִ� �� ���(����, port)�� ���
        foreach (string port in ports)
        {
            print(port);
        }

        ///
        // arduino ��ü�� ��Ʈ �̸�, ��� �ӵ��� ���� �ʱ�ȭ
        ///
        arduino = new SerialPort(portName.ToString(), 9600);

        ///
        // arduino ��Ʈ ����
        ///
        arduino.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if (arduino.IsOpen)
        {
            try
            {
                serialIn = arduino.ReadLine();
                print("raw:" + serialIn);
                if(serialIn != null)
                {
                    serialIn = serialIn.Trim();
                    print("trimmed:" + serialIn);
                }
            }
            catch (Exception e)
            {
                print(e);
            }
        }

    }
    void OnApplicationQuit()
    {
        arduino.Close();
    }
}

