// Based on https://www.geeksforgeeks.org/multiply-large-numbers-represented-as-strings/

string multiply(string num1, string num2){

    int len1 = num1.Length;
    int len2 = num2.Length;
    
    // Simulate Multiplication Like this
    //   1234
    //    121
    //   ----
    //   1234
    //  2468
    // 1234
    //
    // Notice that the product is moved one space to the left each time a digit
    // of the top number is multiplied by the next digit from the right in the
    // bottom number. This is due to place value.

    // Create an array to hold the product of each digit of `num1` and each
    // digit of `num2`. Allocate enough space to move the product over one more
    // space to the left for each digit after the ones place in `num2`.
    int[] products = new int[num1.Length + num2.Length - 1];

    // The index will be filled in from the right. For the ones place of `num`
    // that is the only adjustment to the index.
    int products_index = products.Length -1;
    int product_index_offset = 0;

    // Get the digits of the first number from right to left.
    for (int i = len1 - 1; i >=0; i--)
    {
        int factor1 = Int32.Parse(num1[i].ToString());

        // Get the digits of the second number from right to left.
        for (int j = len2-1; j>=0; j--)
        {
            int factor2 = Int32.Parse(num2[j].ToString());

            // Find the product.
            int current_product = factor1 * factor2;
            // Console.WriteLine(current_product);
            
            // Write the product to the correct position in the products array.
            products[products_index + product_index_offset] += current_product;
            products_index -= 1;
        }

        // Reset the index to the end of the array.
        products_index = products.Length -1;
        // Move the starting point one space to the left.
        product_index_offset -= 1;
    }

    // For each index, store the ones digit of the value stored there and 
    // carry all higher digits to the next value to the left.
    for (int i = products.Length - 1; i >= 0; i--)
    {
        // Get the ones digit.
        int keep = products[i] % 10;
        // Get everything higher than the ones digit.
        int carry = products[i] / 10;
                
        products[i] = keep;
        
        // If index 0 is reached, there is no place to store a carried value.
        // Instead retain it at the current index.
        if (i > 0){
            products[i-1] += carry;
        }
        else{
            products[i] += 10 * carry;
        }
    }

    /*
    foreach (int k in products)
    {
        Console.Write(k.ToString() + " ");
    }

    Console.WriteLine();
    */

    // Convert to string.
    string output = "";
    foreach (int i in products)
    {
        output += i.ToString();
    }

    return output;
}


string actual = "";
string expected = "";

expected = "1078095";
actual = multiply("8765", "123");
Console.WriteLine(expected);
Console.WriteLine(actual);

expected = "41549622603955309777243716069997997007620439937711509062916";
actual = multiply("654154154151454545415415454", "63516561563156316545145146514654");
Console.WriteLine(expected);
Console.WriteLine(actual);
