/*
    !program name: Hassan_ihsan_tempconvertable
    *purpose: the interface for converter
    *programmer: hassan Ihsan
    *date 4/21/2020
*/

//interface
public interface Hassan_ihsan_TempConvertable
{   
    //absolute values
    double ABS_ZERO_K = 0.0;
    double ABS_ZERO_C = -273.15;
    double ABS_ZERO_F = -459.66999999;

    public abstract double convertFtoC(double fTemp);
    public abstract double convertCtoF(double cTemp);
    public abstract double convertCtoK(double cTemp);
    public abstract double convertKtoC(double kTemp);
    public abstract double convertFtoK(double FTemp);
    public abstract double convertKtoF(double kTemp);

}