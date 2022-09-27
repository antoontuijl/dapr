https://bitoftech.net/2022/08/25/deploy-microservice-application-azure-container-apps/

Provision Azure Resources:
- az group create --name "tasks-tracker-rg" --location "westeurope"
- az acr create --resource-group "tasks-tracker-rg" --name "taskstrackerantoontuijlacr" --sku Basic --admin-enabled true
- az acr build --registry "taskstrackerantoontuijlacr" --image "tasksmanager/tasksmanager-backend-api" --file 'TasksTracker.TasksManager.Backend.Api/Dockerfile' .
- az containerapp env create --name "tasks-tracker-containerapps-dev" --resource-group "tasks-tracker-rg" --location "westeurope"
- az containerapp create --name "tasksmanager-backend-api" --resource-group "tasks-tracker-rg" --environment "tasks-tracker-containerapps-dev" --image "taskstrackerantoontuijlacr.azurecr.io/tasksmanager/tasksmanager-backend-api" --registry-server "taskstrackerantoontuijlacr.azurecr.io" --target-port 80 --ingress 'external' --min-replicas 1 --max-replicas 2 --cpu 0.25 --memory 0.5Gi --query configuration.ingress.fqdn