package com.androidevlinux.percy.UTXO.Retrofit;

import com.androidevlinux.percy.UTXO.Beans.BitfinexPubTickerResponseBean;
import com.androidevlinux.percy.UTXO.Beans.GetCurrenciesResponseBean;
import com.androidevlinux.percy.UTXO.Beans.GetMinAmountReponseBean;
import com.androidevlinux.percy.UTXO.Beans.MainBodyBean;
import com.androidevlinux.percy.UTXO.Beans.TransactionBean;

import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.GET;
import retrofit2.http.Header;
import retrofit2.http.POST;

/**
 * Created by percy on 14/11/2017.
 */

public interface InterfaceAPI {
    @POST("/")
    Call<GetCurrenciesResponseBean> getCurrencies(@Header("Content-Type") String content_type, @Header("api-key") String api_key, @Header("sign") String sign, @Body MainBodyBean mainBodyBean);
}
