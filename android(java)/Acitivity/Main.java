private void getCurrencies(){
        MainBodyBean mainBodyBean=new MainBodyBean();
        mainBodyBean.setId(1);
        mainBodyBean.setJsonrpc("2.0");
        mainBodyBean.setMethod("getCurrencies");
        ParamsBean params=new ParamsBean();
        mainBodyBean.setParams(params);
        String sign=null;
        try{
        sign=Utils.hmacDigest(new Gson().toJson(mainBodyBean),Constants.secret_key);
        }catch(Exception e){
        e.printStackTrace();
        }
        InterfaceAPI service=RetrofitBaseAPi.getClient().create(InterfaceAPI.class);
        Call<GetCurrenciesResponseBean> call=service.getCurrencies("application/json",Constants.api_key,sign,mainBodyBean);
        call.enqueue(new Callback<GetCurrenciesResponseBean>(){
@Override
public void onResponse(@NonNull Call<GetCurrenciesResponseBean> call,@NonNull Response<GetCurrenciesResponseBean> response){
        Log.i("DownloadFlagSuccess",response.body().getResult().toString());
        }

@Override
public void onFailure(@NonNull Call<GetCurrenciesResponseBean> call,@NonNull Throwable t){
        Log.i("DownloadFlagFail",t.getMessage());
        }
        });
}