FROM microsoft/aspnetcore:2.0.3-jessie

WORKDIR /home/app

#Copy current folder to /home/app
ADD . /home/app


ENV ASPNETCORE_URLS http://+:5000
ENV DATABASE_USER market_data_app
ENV DATABASE_PASS market_data_app
ENV DATABASE_BASE market_data

CMD dotnet DOTNETMVC.dll
