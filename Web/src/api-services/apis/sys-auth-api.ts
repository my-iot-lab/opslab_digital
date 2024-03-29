/* tslint:disable */
/* eslint-disable */
/**
 * Admin.NET
 * 让 .NET 开发更简单、更通用、更流行。前后端分离架构(.NET6/Vue3)，开箱即用紧随前沿技术。<br/><a href='https://gitee.com/zuohuaijun/Admin.NET/'>https://gitee.com/zuohuaijun/Admin.NET</a>
 *
 * OpenAPI spec version: 1.0.0
 * Contact: 515096995@qq.com
 *
 * NOTE: This class is auto generated by the swagger code generator program.
 * https://github.com/swagger-api/swagger-codegen.git
 * Do not edit the class manually.
 */
import globalAxios, { AxiosResponse, AxiosInstance, AxiosRequestConfig } from 'axios';
import { Configuration } from '../configuration';
// Some imports not used depending on template conditions
// @ts-ignore
import { BASE_PATH, COLLECTION_FORMATS, RequestArgs, BaseAPI, RequiredError } from '../base';
import { AdminResultLoginOutput } from '../models';
import { AdminResultLoginUserOutput } from '../models';
import { AdminResultObject } from '../models';
import { AdminResultString } from '../models';
import { LoginInput } from '../models';
/**
 * SysAuthApi - axios parameter creator
 * @export
 */
export const SysAuthApiAxiosParamCreator = function (configuration?: Configuration) {
    return {
        /**
         * 
         * @summary 生成图片验证码
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        captchaGet: async (options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/captcha`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary 登录配置
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        loginConfigGet: async (options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/loginConfig`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 用户名/密码：superadmin/123456
         * @summary 登录系统
         * @param {LoginInput} body 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        loginPost: async (body: LoginInput, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            // verify required parameter 'body' is not null or undefined
            if (body === null || body === undefined) {
                throw new RequiredError('body','Required parameter body was null or undefined when calling loginPost.');
            }
            const localVarPath = `/login`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            localVarHeaderParameter['Content-Type'] = 'application/json-patch+json';

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};
            const needsSerialization = (typeof body !== "string") || localVarRequestOptions.headers['Content-Type'] === 'application/json';
            localVarRequestOptions.data =  needsSerialization ? JSON.stringify(body !== undefined ? body : {}) : (body || "");

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary 退出系统
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        logoutPost: async (options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/logout`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary 获取刷新Token
         * @param {string} accessToken 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        refreshTokenPost: async (accessToken: string, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            // verify required parameter 'accessToken' is not null or undefined
            if (accessToken === null || accessToken === undefined) {
                throw new RequiredError('accessToken','Required parameter accessToken was null or undefined when calling refreshTokenPost.');
            }
            const localVarPath = `/refreshToken`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            if (accessToken !== undefined) {
                localVarQueryParameter['accessToken'] = accessToken;
            }

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary Swagger登录检查
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        swaggerCheckUrlPost: async (options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/Swagger/CheckUrl`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary Swagger登录
         * @param {string} [userName] 
         * @param {string} [password] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        swaggerSubmitUrlPostForm: async (userName?: string, password?: string, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/Swagger/SubmitUrl`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'POST', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;
            const localVarFormParams = new FormData();

            // authentication Bearer required


            if (userName !== undefined) { 
                localVarFormParams.append('UserName', userName as any);
            }

            if (password !== undefined) { 
                localVarFormParams.append('Password', password as any);
            }

            localVarHeaderParameter['Content-Type'] = 'multipart/form-data';
            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};
            localVarRequestOptions.data = localVarFormParams;

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
        /**
         * 
         * @summary 获取用户信息
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        userInfoGet: async (options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/userInfo`;
            // use dummy base URL string because the URL constructor only accepts absolute URLs.
            const localVarUrlObj = new URL(localVarPath, 'https://example.com');
            let baseOptions;
            if (configuration) {
                baseOptions = configuration.baseOptions;
            }
            const localVarRequestOptions :AxiosRequestConfig = { method: 'GET', ...baseOptions, ...options};
            const localVarHeaderParameter = {} as any;
            const localVarQueryParameter = {} as any;

            // authentication Bearer required

            const query = new URLSearchParams(localVarUrlObj.search);
            for (const key in localVarQueryParameter) {
                query.set(key, localVarQueryParameter[key]);
            }
            for (const key in options.params) {
                query.set(key, options.params[key]);
            }
            localVarUrlObj.search = (new URLSearchParams(query)).toString();
            let headersFromBaseOptions = baseOptions && baseOptions.headers ? baseOptions.headers : {};
            localVarRequestOptions.headers = {...localVarHeaderParameter, ...headersFromBaseOptions, ...options.headers};

            return {
                url: localVarUrlObj.pathname + localVarUrlObj.search + localVarUrlObj.hash,
                options: localVarRequestOptions,
            };
        },
    }
};

/**
 * SysAuthApi - functional programming interface
 * @export
 */
export const SysAuthApiFp = function(configuration?: Configuration) {
    return {
        /**
         * 
         * @summary 生成图片验证码
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async captchaGet(options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultObject>>> {
            const localVarAxiosArgs = await SysAuthApiAxiosParamCreator(configuration).captchaGet(options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 登录配置
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async loginConfigGet(options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultObject>>> {
            const localVarAxiosArgs = await SysAuthApiAxiosParamCreator(configuration).loginConfigGet(options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 用户名/密码：superadmin/123456
         * @summary 登录系统
         * @param {LoginInput} body 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async loginPost(body: LoginInput, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultLoginOutput>>> {
            const localVarAxiosArgs = await SysAuthApiAxiosParamCreator(configuration).loginPost(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 退出系统
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async logoutPost(options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<void>>> {
            const localVarAxiosArgs = await SysAuthApiAxiosParamCreator(configuration).logoutPost(options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 获取刷新Token
         * @param {string} accessToken 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async refreshTokenPost(accessToken: string, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultString>>> {
            const localVarAxiosArgs = await SysAuthApiAxiosParamCreator(configuration).refreshTokenPost(accessToken, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary Swagger登录检查
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async swaggerCheckUrlPost(options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<number>>> {
            const localVarAxiosArgs = await SysAuthApiAxiosParamCreator(configuration).swaggerCheckUrlPost(options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary Swagger登录
         * @param {string} [userName] 
         * @param {string} [password] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async swaggerSubmitUrlPostForm(userName?: string, password?: string, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<number>>> {
            const localVarAxiosArgs = await SysAuthApiAxiosParamCreator(configuration).swaggerSubmitUrlPostForm(userName, password, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 获取用户信息
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async userInfoGet(options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultLoginUserOutput>>> {
            const localVarAxiosArgs = await SysAuthApiAxiosParamCreator(configuration).userInfoGet(options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
    }
};

/**
 * SysAuthApi - factory interface
 * @export
 */
export const SysAuthApiFactory = function (configuration?: Configuration, basePath?: string, axios?: AxiosInstance) {
    return {
        /**
         * 
         * @summary 生成图片验证码
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async captchaGet(options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultObject>> {
            return SysAuthApiFp(configuration).captchaGet(options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 登录配置
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async loginConfigGet(options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultObject>> {
            return SysAuthApiFp(configuration).loginConfigGet(options).then((request) => request(axios, basePath));
        },
        /**
         * 用户名/密码：superadmin/123456
         * @summary 登录系统
         * @param {LoginInput} body 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async loginPost(body: LoginInput, options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultLoginOutput>> {
            return SysAuthApiFp(configuration).loginPost(body, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 退出系统
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async logoutPost(options?: AxiosRequestConfig): Promise<AxiosResponse<void>> {
            return SysAuthApiFp(configuration).logoutPost(options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 获取刷新Token
         * @param {string} accessToken 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async refreshTokenPost(accessToken: string, options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultString>> {
            return SysAuthApiFp(configuration).refreshTokenPost(accessToken, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary Swagger登录检查
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async swaggerCheckUrlPost(options?: AxiosRequestConfig): Promise<AxiosResponse<number>> {
            return SysAuthApiFp(configuration).swaggerCheckUrlPost(options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary Swagger登录
         * @param {string} [userName] 
         * @param {string} [password] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async swaggerSubmitUrlPostForm(userName?: string, password?: string, options?: AxiosRequestConfig): Promise<AxiosResponse<number>> {
            return SysAuthApiFp(configuration).swaggerSubmitUrlPostForm(userName, password, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 获取用户信息
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async userInfoGet(options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultLoginUserOutput>> {
            return SysAuthApiFp(configuration).userInfoGet(options).then((request) => request(axios, basePath));
        },
    };
};

/**
 * SysAuthApi - object-oriented interface
 * @export
 * @class SysAuthApi
 * @extends {BaseAPI}
 */
export class SysAuthApi extends BaseAPI {
    /**
     * 
     * @summary 生成图片验证码
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof SysAuthApi
     */
    public async captchaGet(options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultObject>> {
        return SysAuthApiFp(this.configuration).captchaGet(options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 登录配置
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof SysAuthApi
     */
    public async loginConfigGet(options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultObject>> {
        return SysAuthApiFp(this.configuration).loginConfigGet(options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 用户名/密码：superadmin/123456
     * @summary 登录系统
     * @param {LoginInput} body 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof SysAuthApi
     */
    public async loginPost(body: LoginInput, options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultLoginOutput>> {
        return SysAuthApiFp(this.configuration).loginPost(body, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 退出系统
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof SysAuthApi
     */
    public async logoutPost(options?: AxiosRequestConfig) : Promise<AxiosResponse<void>> {
        return SysAuthApiFp(this.configuration).logoutPost(options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 获取刷新Token
     * @param {string} accessToken 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof SysAuthApi
     */
    public async refreshTokenPost(accessToken: string, options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultString>> {
        return SysAuthApiFp(this.configuration).refreshTokenPost(accessToken, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary Swagger登录检查
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof SysAuthApi
     */
    public async swaggerCheckUrlPost(options?: AxiosRequestConfig) : Promise<AxiosResponse<number>> {
        return SysAuthApiFp(this.configuration).swaggerCheckUrlPost(options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary Swagger登录
     * @param {string} [userName] 
     * @param {string} [password] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof SysAuthApi
     */
    public async swaggerSubmitUrlPostForm(userName?: string, password?: string, options?: AxiosRequestConfig) : Promise<AxiosResponse<number>> {
        return SysAuthApiFp(this.configuration).swaggerSubmitUrlPostForm(userName, password, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 获取用户信息
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof SysAuthApi
     */
    public async userInfoGet(options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultLoginUserOutput>> {
        return SysAuthApiFp(this.configuration).userInfoGet(options).then((request) => request(this.axios, this.basePath));
    }
}
