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
import { AdminResultObject } from '../models';
import { AdminResultString } from '../models';
import { GenAuthUrlInput } from '../models';
import { SignatureInput } from '../models';
import { WechatOAuth2Input } from '../models';
import { WechatUserLogin } from '../models';
/**
 * SysWechatApi - axios parameter creator
 * @export
 */
export const SysWechatApiAxiosParamCreator = function (configuration?: Configuration) {
    return {
        /**
         * 
         * @summary 生成网页授权Url
         * @param {GenAuthUrlInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysWechatGenAuthUrlPost: async (body?: GenAuthUrlInput, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/sysWechat/genAuthUrl`;
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
         * @summary 获取配置签名参数(wx.config)
         * @param {SignatureInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysWechatGenConfigParaPost: async (body?: SignatureInput, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/sysWechat/genConfigPara`;
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
         * @summary 微信用户登录
         * @param {WechatUserLogin} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysWechatOpenIdLoginPost: async (body?: WechatUserLogin, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            const localVarPath = `/sysWechat/openIdLogin`;
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
         * @summary 授权登录(Code换取OpenId)
         * @param {WechatOAuth2Input} body 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        sysWechatSnsOAuth2Post: async (body: WechatOAuth2Input, options: AxiosRequestConfig = {}): Promise<RequestArgs> => {
            // verify required parameter 'body' is not null or undefined
            if (body === null || body === undefined) {
                throw new RequiredError('body','Required parameter body was null or undefined when calling sysWechatSnsOAuth2Post.');
            }
            const localVarPath = `/sysWechat/snsOAuth2`;
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
    }
};

/**
 * SysWechatApi - functional programming interface
 * @export
 */
export const SysWechatApiFp = function(configuration?: Configuration) {
    return {
        /**
         * 
         * @summary 生成网页授权Url
         * @param {GenAuthUrlInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysWechatGenAuthUrlPost(body?: GenAuthUrlInput, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultString>>> {
            const localVarAxiosArgs = await SysWechatApiAxiosParamCreator(configuration).sysWechatGenAuthUrlPost(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 获取配置签名参数(wx.config)
         * @param {SignatureInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysWechatGenConfigParaPost(body?: SignatureInput, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultObject>>> {
            const localVarAxiosArgs = await SysWechatApiAxiosParamCreator(configuration).sysWechatGenConfigParaPost(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 微信用户登录
         * @param {WechatUserLogin} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysWechatOpenIdLoginPost(body?: WechatUserLogin, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultObject>>> {
            const localVarAxiosArgs = await SysWechatApiAxiosParamCreator(configuration).sysWechatOpenIdLoginPost(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
        /**
         * 
         * @summary 授权登录(Code换取OpenId)
         * @param {WechatOAuth2Input} body 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysWechatSnsOAuth2Post(body: WechatOAuth2Input, options?: AxiosRequestConfig): Promise<(axios?: AxiosInstance, basePath?: string) => Promise<AxiosResponse<AdminResultString>>> {
            const localVarAxiosArgs = await SysWechatApiAxiosParamCreator(configuration).sysWechatSnsOAuth2Post(body, options);
            return (axios: AxiosInstance = globalAxios, basePath: string = BASE_PATH) => {
                const axiosRequestArgs :AxiosRequestConfig = {...localVarAxiosArgs.options, url: basePath + localVarAxiosArgs.url};
                return axios.request(axiosRequestArgs);
            };
        },
    }
};

/**
 * SysWechatApi - factory interface
 * @export
 */
export const SysWechatApiFactory = function (configuration?: Configuration, basePath?: string, axios?: AxiosInstance) {
    return {
        /**
         * 
         * @summary 生成网页授权Url
         * @param {GenAuthUrlInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysWechatGenAuthUrlPost(body?: GenAuthUrlInput, options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultString>> {
            return SysWechatApiFp(configuration).sysWechatGenAuthUrlPost(body, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 获取配置签名参数(wx.config)
         * @param {SignatureInput} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysWechatGenConfigParaPost(body?: SignatureInput, options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultObject>> {
            return SysWechatApiFp(configuration).sysWechatGenConfigParaPost(body, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 微信用户登录
         * @param {WechatUserLogin} [body] 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysWechatOpenIdLoginPost(body?: WechatUserLogin, options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultObject>> {
            return SysWechatApiFp(configuration).sysWechatOpenIdLoginPost(body, options).then((request) => request(axios, basePath));
        },
        /**
         * 
         * @summary 授权登录(Code换取OpenId)
         * @param {WechatOAuth2Input} body 
         * @param {*} [options] Override http request option.
         * @throws {RequiredError}
         */
        async sysWechatSnsOAuth2Post(body: WechatOAuth2Input, options?: AxiosRequestConfig): Promise<AxiosResponse<AdminResultString>> {
            return SysWechatApiFp(configuration).sysWechatSnsOAuth2Post(body, options).then((request) => request(axios, basePath));
        },
    };
};

/**
 * SysWechatApi - object-oriented interface
 * @export
 * @class SysWechatApi
 * @extends {BaseAPI}
 */
export class SysWechatApi extends BaseAPI {
    /**
     * 
     * @summary 生成网页授权Url
     * @param {GenAuthUrlInput} [body] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof SysWechatApi
     */
    public async sysWechatGenAuthUrlPost(body?: GenAuthUrlInput, options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultString>> {
        return SysWechatApiFp(this.configuration).sysWechatGenAuthUrlPost(body, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 获取配置签名参数(wx.config)
     * @param {SignatureInput} [body] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof SysWechatApi
     */
    public async sysWechatGenConfigParaPost(body?: SignatureInput, options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultObject>> {
        return SysWechatApiFp(this.configuration).sysWechatGenConfigParaPost(body, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 微信用户登录
     * @param {WechatUserLogin} [body] 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof SysWechatApi
     */
    public async sysWechatOpenIdLoginPost(body?: WechatUserLogin, options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultObject>> {
        return SysWechatApiFp(this.configuration).sysWechatOpenIdLoginPost(body, options).then((request) => request(this.axios, this.basePath));
    }
    /**
     * 
     * @summary 授权登录(Code换取OpenId)
     * @param {WechatOAuth2Input} body 
     * @param {*} [options] Override http request option.
     * @throws {RequiredError}
     * @memberof SysWechatApi
     */
    public async sysWechatSnsOAuth2Post(body: WechatOAuth2Input, options?: AxiosRequestConfig) : Promise<AxiosResponse<AdminResultString>> {
        return SysWechatApiFp(this.configuration).sysWechatSnsOAuth2Post(body, options).then((request) => request(this.axios, this.basePath));
    }
}
