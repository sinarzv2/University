# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0  AS runtime

RUN mkdir /usr/share/services/university -p
WORKDIR /usr/share/services/university
COPY ./Publish /usr/share/services/university

ENV ConfigServer=
ENV spring__cloud__config__failFast=true

ENV TZ=Asia/Tehran
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

RUN dpkg-reconfigure -f noninteractive tzdata

EXPOSE 80 80/tcp

ENTRYPOINT ["dotnet", "University.dll"]
